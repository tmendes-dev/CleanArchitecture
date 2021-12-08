using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchitecture.Domain.Tests
{
    public class CategoryUnitTest
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category With Negative Id")]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Create Category With Short Name")]
        public void CreateCategory_ShortName_DomainExceptionInvalidId()
        {
            Action action = () => new Category(1, "Ca");
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Create Category With Missing Name")]
        public void CreateCategory_MissingName_DomainExceptionInvalidId()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create Category With Null Name")]
        public void CreateCategory_NullName_DomainExceptionInvalidId()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Invalid name. Name is required");
        }
    }
}
