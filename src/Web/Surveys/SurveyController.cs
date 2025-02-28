using Microsoft.AspNetCore.Mvc;
using QuestionnaireSystem.Application.Interviews;
using QuestionnaireSystem.Application.Questions;
using QuestionnaireSystem.Application.Results;
using QuestionnaireSystem.Domain;
using QuestionnaireSystem.Web.Answers;
using QuestionnaireSystem.Web.Questions;

namespace QuestionnaireSystem.Web.Surveys;

[Route("api/surveys")]
[ApiController]
public sealed class SurveyController : ControllerBase
{
    private readonly IInterviewService interviewService;
    private readonly IQuestionService questionService;
    private readonly IResultService resultService;

    public SurveyController(
        IInterviewService interviewService,
        IQuestionService questionService,
        IResultService resultService)
    {
        this.interviewService = interviewService;
        this.questionService = questionService;
        this.resultService = resultService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }
    
    [HttpGet("{surveyId}/questions/{questionId?}")]
    public async Task<IActionResult> GetQuestionAsync(
        [FromRoute] Guid surveyId,
        [FromRoute] Guid? questionId,
        CancellationToken cancellationToken)
    {
        var interviewId = HttpContext.Request.Cookies[$"interviewId_{surveyId}"];

        Interview interview;
        
        if (string.IsNullOrEmpty(interviewId))
        {
            interview = await interviewService.CreateInterviewAsync(surveyId, cancellationToken);
            HttpContext.Response.Cookies.Append($"interviewId_{surveyId}", interview.Id.ToString());
        }
        else if (Guid.TryParse(interviewId, out Guid parsedInterviewId))
        { 
            interview = await interviewService.GetInterviewByIdAsync(parsedInterviewId, surveyId, cancellationToken);
        }
        else
        {
            return BadRequest("Invalid interviewId");
        }

        if (questionId.HasValue && questionId != interview.CurrentQuestionId)
        {
            return BadRequest("Invalid questionId");
        }

        var question = await questionService.GetQuestionByIdAsync(questionId ?? interview.CurrentQuestionId, cancellationToken);

        var questionResponse = question.MapToQuestionResponse();
        
        return Ok(questionResponse);
    }

    [HttpPost("{surveyId}/questions/{questionId}/answers")]
    public async Task<IActionResult> AddResultAsync(
        [FromRoute] Guid surveyId,
        [FromRoute] Guid questionId,
        [FromBody] AnswerRequest answerRequest,
        CancellationToken cancellationToken)
    {
        var interviewId = HttpContext.Request.Cookies[$"interviewId_{surveyId}"];

        if (string.IsNullOrEmpty(interviewId))
        {
            return BadRequest("Invalid interviewId");
        }
        
        if (!Guid.TryParse(interviewId, out Guid parsedInterviewId))
        { 
            return BadRequest("Invalid interviewId");
        }

        var command = new SaveAnswerCommand(
            questionId,
            parsedInterviewId,
            surveyId,
            answerRequest.AnswerIds);
        
        var nextQuestionId = await resultService.SaveAnswerAndReturnNextQuestionIdAsync(command, cancellationToken);

        if (nextQuestionId == Guid.Empty)
        {
            HttpContext.Response.Cookies.Delete($"interviewId_{surveyId}");
            
            return NoContent();
        }
        
        return Ok(nextQuestionId);
    }
}