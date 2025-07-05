using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ECommerce.RestAPI.Entities;
using FluentAssertions;
using Xunit;

namespace ECommerce.RestAPI.Tests.Entities
{
    public class ReviewTests
    {
        private Review CreateValidReview() => new Review
        {
            Comment = "Great product!",
            RatingScore = ECommerce.RestAPI.Entities.Enums.Rating.Excellent,
            UserId = Guid.NewGuid(),
            ProductId = Guid.NewGuid()
        };

        [Fact]
        public void Review_WithValidData_ShouldBeValid()
        {
            var review = CreateValidReview();
            var results = new List<ValidationResult>();
            var context = new ValidationContext(review);
            var isValid = Validator.TryValidateObject(review, context, results, true);
            isValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        public void Review_MissingOrEmptyComment_ShouldBeInvalid(string comment)
        {
            var review = CreateValidReview();
            review.Comment = comment;
            var results = new List<ValidationResult>();
            var context = new ValidationContext(review);
            var isValid = Validator.TryValidateObject(review, context, results, true);
            isValid.Should().BeFalse();
        }

        [Fact]
        public void Review_CommentTooLong_ShouldBeInvalid()
        {
            var review = CreateValidReview();
            review.Comment = new string('a', 1001);
            var results = new List<ValidationResult>();
            var context = new ValidationContext(review);
            var isValid = Validator.TryValidateObject(review, context, results, true);
            isValid.Should().BeFalse();
        }
    }
}
