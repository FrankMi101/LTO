// <copyright file="CommonActionTest.cs">Copyright ©  2018</copyright>
using System;
using AppOperate;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppOperate.Tests
{
    /// <summary>This class contains parameterized unit tests for CommonAction</summary>
    [PexClass(typeof(CommonAction))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class CommonActionTest
    {
    }
}
