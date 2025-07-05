using System;
using ECommerce.RestAPI.Entities;
using ECommerce.RestAPI.Validators;
using FluentAssertions;
using Xunit;

namespace ECommerce.RestAPI.Tests.Validators
{
    public class QuestionValidatorTests
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
            var validator = new QuestionValidator();
            var result = validator.Validate(question);
            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        public void Question_MissingOrEmptyQuest_ShouldBeInvalid(string quest)
        {
            var question = CreateValidQuestion();
            question.Quest = quest;
            var validator = new QuestionValidator();
            var result = validator.Validate(question);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "Quest");
        }

        [Fact]
        public void Question_QuestTooLong_ShouldBeInvalid()
        {
            var question = CreateValidQuestion();
            question.Quest = new string('A', 501);
            var validator = new QuestionValidator();
            var result = validator.Validate(question);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "Quest");
        }

        [Fact]
        public void Question_MissingUserId_ShouldBeInvalid()
        {
            var question = CreateValidQuestion();
            question.UserId = Guid.Empty;
            var validator = new QuestionValidator();
            var result = validator.Validate(question);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "UserId");
        }

        [Fact]
        public void Question_MissingProductId_ShouldBeInvalid()
        {
            var question = CreateValidQuestion();
            question.ProductId = Guid.Empty;
            var validator = new QuestionValidator();
            var result = validator.Validate(question);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "ProductId");
        }
    }
}
