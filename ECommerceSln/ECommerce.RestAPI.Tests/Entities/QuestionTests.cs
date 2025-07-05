using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ECommerce.RestAPI.Entities;
using FluentAssertions;
using Xunit;

namespace ECommerce.RestAPI.Tests.Entities
{
    public class QuestionTests
    {
        private Question CreateValidQuestion() => new Question
        {
            Quest = "What is the warranty period?",
            UserId = Guid.NewGuid(),
            ProductId = Guid.NewGuid()
        };

        [Fact]
        public void Question_WithValidData_ShouldBeValid()
        {
            var question = CreateValidQuestion();
            var results = new List<ValidationResult>();
            var context = new ValidationContext(question);
            var isValid = Validator.TryValidateObject(question, context, results, true);
            isValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        public void Question_MissingOrEmptyQuest_ShouldBeInvalid(string quest)
        {
            var question = CreateValidQuestion();
            question.Quest = quest;
            var results = new List<ValidationResult>();
            var context = new ValidationContext(question);
            var isValid = Validator.TryValidateObject(question, context, results, true);
            isValid.Should().BeFalse();
        }

        [Fact]
        public void Question_QuestTooLong_ShouldBeInvalid()
        {
            var question = CreateValidQuestion();
            question.Quest = new string('a', 501);
            var results = new List<ValidationResult>();
            var context = new ValidationContext(question);
            var isValid = Validator.TryValidateObject(question, context, results, true);
            isValid.Should().BeFalse();
        }
    }
}
