using Shouldly;
using System;
using Xunit;
using Yuya.Net.OData.Server;
using Yuya.Net.OData.Server.Operations;
using Yuya.Net.Serializers;

namespace Yuya.Net.Core.Tests
{
    public class QueryStringResolverTests
    {
        [Fact]
        public void Should_DecodeUrl_When_ParametersIsNull_Then_ReturnNull()
        {
            QueryStringResolver queryStringResolver = new QueryStringResolver();
            var a = queryStringResolver.DecodeUrl(null);
            a.ShouldBeNull();
        }

        [Fact]
        public void Should_DecodeUrl_When_ParametersIsEmpty_Then_ReturnEmpty()
        {
            QueryStringResolver queryStringResolver = new QueryStringResolver();
            var a = queryStringResolver.DecodeUrl(string.Empty);
            a.ShouldBeEmpty();
        }

        [Fact]
        public void Should_DecodeUrl_When_ParametersIsNormalCharacters_Then_ReturnSame()
        {
            QueryStringResolver queryStringResolver = new QueryStringResolver();
            var a = queryStringResolver.DecodeUrl("AaBbCcDdEe");
            a.ShouldBe("AaBbCcDdEe");
        }

        [Fact]
        public void Should_DecodeUrl_When_ParametersIsEscapedCharacters_Then_ReturnSame()
        {
            QueryStringResolver queryStringResolver = new QueryStringResolver();
            var a = queryStringResolver.DecodeUrl("Aa%3D%26%25");
            a.ShouldBe("Aa=&%");
        }

        [Fact]
        public void Should_GetOperationInfoByUrl_When_ParametersIsNull_Then_ThrowException()
        {
            QueryStringResolver queryStringResolver = new QueryStringResolver();
            Should.Throw<ArgumentNullException>(() => queryStringResolver.GetOperationInfoByUrl(null, null));
        }

        [Fact]
        public void Should_GetOperationInfoByUrl_When_UrlParameterIsEmpty_Then_ThrowException()
        {
            QueryStringResolver queryStringResolver = new QueryStringResolver();
            Should.Throw<ArgumentNullException>(() => queryStringResolver.GetOperationInfoByUrl("", null));
        }


        //[Fact]
        //public void Should_GetOperationInfoByUrl_When_UrlParameterIsListUrl_Then_ReturnListOperationInfo()
        //{
        //    QueryStringResolver queryStringResolver = new QueryStringResolver();
        //    var a = queryStringResolver.GetOperationInfoByUrl("/odata/v4/Person", "/odata/v4");

        //    a.ShouldBeOfType<ListOperationInfo>();
        //    a.EntityName.ShouldBe("Person");
        //}

        //[Fact]
        //public void Should_GetOperationInfoByUrl_When_UrlParameterIsListUrlWithoutBaseUrl_Then_ReturnListOperationInfo()
        //{
        //    QueryStringResolver queryStringResolver = new QueryStringResolver();
        //    var a = queryStringResolver.GetOperationInfoByUrl("/Person");

        //    a.ShouldBeOfType<ListOperationInfo>();
        //    a.EntityName.ShouldBe("Person");
        //}

        //[Fact]
        //public void Should_GetOperationInfoByUrl_When_UrlParameterIsListUrlWithNullBaseUrl_Then_ReturnListOperationInfo()
        //{
        //    QueryStringResolver queryStringResolver = new QueryStringResolver();
        //    var a = queryStringResolver.GetOperationInfoByUrl("/Person", null);

        //    a.ShouldBeOfType<ListOperationInfo>();
        //    a.EntityName.ShouldBe("Person");
        //}

        //[Fact]
        //public void Should_GetOperationInfoByUrl_When_UrlParameterIsListUrlWithEmptyBaseUrl_Then_ReturnListOperationInfo()
        //{
        //    QueryStringResolver queryStringResolver = new QueryStringResolver();
        //    var a = queryStringResolver.GetOperationInfoByUrl("/Person", "");

        //    a.ShouldBeOfType<ListOperationInfo>();
        //    a.EntityName.ShouldBe("Person");
        //}

        //[Fact]
        //public void Should_GetOperationInfoByUrl_When_UrlParameterIsntStartSlashCharacter_Then_ReturnListOperationInfo()
        //{
        //    QueryStringResolver queryStringResolver = new QueryStringResolver();
        //    var a = queryStringResolver.GetOperationInfoByUrl("Person");

        //    a.ShouldBeOfType<ListOperationInfo>();
        //    a.EntityName.ShouldBe("Person");
        //}

        //[Fact]
        //public void Should_GetOperationInfoByUrl_When_UrlParameterHasEndsWithSlashCharacter_Then_ReturnListOperationInfo()
        //{
        //    QueryStringResolver queryStringResolver = new QueryStringResolver();
        //    var a = queryStringResolver.GetOperationInfoByUrl("Person/");

        //    a.ShouldBeOfType<ListOperationInfo>();
        //    a.EntityName.ShouldBe("Person");
        //}

        //[Fact]
        //public void Should_GetOperationInfoByUrl_When_UrlParameterIsGetByIdUrl_Then_ReturnGetByIdOperationInfo()
        //{
        //    QueryStringResolver queryStringResolver = new QueryStringResolver();
        //    var a = queryStringResolver.GetOperationInfoByUrl("/odata/v4/Person('a')", "/odata/v4");

        //    a.ShouldBeOfType<GetByIdOperationInfo>();
        //    a.EntityName.ShouldBe("Person");
        //    var b = a as GetByIdOperationInfo;
        //    b.Id.ShouldBe("a");
        //}

        //// People?$top=2 & $filter=Trips/any(d:d/Budget gt 3000)
        //[Fact]
        //public void Should_GetOperationInfoByUrl_When_UrlParameterIsQueryUrl_Then_ReturnQueryOperationInfo()
        //{
        //    QueryStringResolver queryStringResolver = new QueryStringResolver();
        //    var a = queryStringResolver.GetOperationInfoByUrl("/odata/v4/Person?$top=2 & $filter=Trips/any(d:d/Budget gt 3000)", "/odata/v4");

        //    a.ShouldBeOfType<QueryOperationInfo>();
        //    a.EntityName.ShouldBe("Person");
        //    var b = a as QueryOperationInfo;
        //    b.Top.ShouldBe(2);
        //    b.FilterString.ShouldBe("Trips/any(d:d/Budget gt 3000)");
        //}

        //// People?$top=2
        //[Fact]
        //public void Should_GetOperationInfoByUrl_When_UrlParameterIsQueryUrlWithOnlyTop_Then_ReturnQueryOperationInfo()
        //{
        //    QueryStringResolver queryStringResolver = new QueryStringResolver();
        //    var a = queryStringResolver.GetOperationInfoByUrl("/odata/v4/Person?$top=2", "/odata/v4");

        //    a.ShouldBeOfType<QueryOperationInfo>();
        //    a.EntityName.ShouldBe("Person");
        //    var b = a as QueryOperationInfo;
        //    b.Top.ShouldBe(2);
        //    b.FilterString.ShouldBeNullOrEmpty();
        //}

        //// People?$top=2 & $filter=Trips/any(d:d/Budget gt 3000)
        //[Fact]
        //public void Should_GetOperationInfoByUrl_When_UrlParameterIsQueryUrlWithOnlyFilter_Then_ReturnQueryOperationInfo()
        //{
        //    QueryStringResolver queryStringResolver = new QueryStringResolver();
        //    var a = queryStringResolver.GetOperationInfoByUrl("/odata/v4/Person?$filter=Trips/any(d:d/Budget gt 3000)", "/odata/v4");

        //    a.ShouldBeOfType<QueryOperationInfo>();
        //    a.EntityName.ShouldBe("Person");
        //    var b = a as QueryOperationInfo;
        //    b.Top.ShouldBeNull();
        //    b.FilterString.ShouldBe("Trips/any(d:d/Budget gt 3000)");
        //}
    }
}
