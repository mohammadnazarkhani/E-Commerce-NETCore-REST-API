using System;
using ECommerce.RestAPI.Entities;
using ECommerce.RestAPI.Validators;
using FluentAssertions;
using Xunit;

namespace ECommerce.RestAPI.Tests.Validators
{
    public class ReviewValidatorTests
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
            var validator = new ReviewValidator();
            var result = validator.Validate(review);
            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        public void Review_MissingOrEmptyComment_ShouldBeInvalid(string comment)
        {
            var review = CreateValidReview();
            review.Comment = comment;
            var validator = new ReviewValidator();
            var result = validator.Validate(review);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "Comment");
        }

        [Fact]
        public void Review_CommentTooLong_ShouldBeInvalid()
        {
            var review = CreateValidReview();
            review.Comment = new string('A', 1001);
            var validator = new ReviewValidator();
            var result = validator.Validate(review);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "Comment");
        }

        [Fact]
        public void Review_InvalidRatingScore_ShouldBeInvalid()
        {
            var review = CreateValidReview();
            review.RatingScore = (ECommerce.RestAPI.Entities.Enums.Rating)99;
            var validator = new ReviewValidator();
            var result = validator.Validate(review);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "RatingScore");
        }

        [Fact]
        public void Review_MissingUserId_ShouldBeInvalid()
        {
            var review = CreateValidReview();
            review.UserId = Guid.Empty;
            var validator = new ReviewValidator();
            var result = validator.Validate(review);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "UserId");
        }

        [Fact]
        public void Review_MissingProductId_ShouldBeInvalid()
        {
            var review = CreateValidReview();
            review.ProductId = Guid.Empty;
            var validator = new ReviewValidator();
            var result = validator.Validate(review);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "ProductId");
        }
    }
}
