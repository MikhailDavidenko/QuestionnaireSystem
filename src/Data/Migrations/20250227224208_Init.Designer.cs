﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using QuestionnaireSystem.Data.Engine;

#nullable disable

namespace QuestionnaireSystem.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250227224208_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("QuestionnaireSystem.Domain.Answer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uuid")
                        .HasColumnName("question_id");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("text");

                    b.HasKey("Id")
                        .HasName("pk_answers");

                    b.HasIndex("QuestionId")
                        .HasDatabaseName("ix_answers_question_id");

                    b.ToTable("answers", (string)null);
                });

            modelBuilder.Entity("QuestionnaireSystem.Domain.Interview", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_date");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_date");

                    b.Property<Guid>("SurveyId")
                        .HasColumnType("uuid")
                        .HasColumnName("survey_id");

                    b.HasKey("Id")
                        .HasName("pk_interviews");

                    b.HasIndex("SurveyId")
                        .HasDatabaseName("ix_interviews_survey_id");

                    b.ToTable("interviews", (string)null);
                });

            modelBuilder.Entity("QuestionnaireSystem.Domain.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("Order")
                        .HasColumnType("integer")
                        .HasColumnName("order");

                    b.Property<Guid>("SurveyId")
                        .HasColumnType("uuid")
                        .HasColumnName("survey_id");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)")
                        .HasColumnName("text");

                    b.HasKey("Id")
                        .HasName("pk_questions");

                    b.HasIndex("Order")
                        .HasDatabaseName("ix_questions_order");

                    b.HasIndex("SurveyId")
                        .HasDatabaseName("ix_questions_survey_id");

                    b.ToTable("questions", (string)null);
                });

            modelBuilder.Entity("QuestionnaireSystem.Domain.Result", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AnswerId")
                        .HasColumnType("uuid")
                        .HasColumnName("answer_id");

                    b.Property<Guid>("InterviewId")
                        .HasColumnType("uuid")
                        .HasColumnName("interview_id");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uuid")
                        .HasColumnName("question_id");

                    b.HasKey("Id")
                        .HasName("pk_results");

                    b.HasIndex("AnswerId")
                        .HasDatabaseName("ix_results_answer_id");

                    b.HasIndex("InterviewId")
                        .HasDatabaseName("ix_results_interview_id");

                    b.HasIndex("QuestionId")
                        .HasDatabaseName("ix_results_question_id");

                    b.ToTable("results", (string)null);
                });

            modelBuilder.Entity("QuestionnaireSystem.Domain.Survey", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("description");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_surveys");

                    b.ToTable("surveys", (string)null);
                });

            modelBuilder.Entity("QuestionnaireSystem.Domain.Answer", b =>
                {
                    b.HasOne("QuestionnaireSystem.Domain.Question", null)
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_answers_questions_question_id");
                });

            modelBuilder.Entity("QuestionnaireSystem.Domain.Interview", b =>
                {
                    b.HasOne("QuestionnaireSystem.Domain.Survey", null)
                        .WithMany()
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_interviews_surveys_survey_id");
                });

            modelBuilder.Entity("QuestionnaireSystem.Domain.Question", b =>
                {
                    b.HasOne("QuestionnaireSystem.Domain.Survey", null)
                        .WithMany()
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_questions_surveys_survey_id");
                });

            modelBuilder.Entity("QuestionnaireSystem.Domain.Result", b =>
                {
                    b.HasOne("QuestionnaireSystem.Domain.Answer", null)
                        .WithMany()
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_results_answers_answer_id");

                    b.HasOne("QuestionnaireSystem.Domain.Interview", null)
                        .WithMany()
                        .HasForeignKey("InterviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_results_interviews_interview_id");

                    b.HasOne("QuestionnaireSystem.Domain.Question", null)
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_results_questions_question_id");
                });
#pragma warning restore 612, 618
        }
    }
}
