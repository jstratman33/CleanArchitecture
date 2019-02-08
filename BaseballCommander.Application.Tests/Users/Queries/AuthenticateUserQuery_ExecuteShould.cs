//using BaseballCommander.Application.Users.Queries.AuthenticateUser;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace BaseballCommander.Application.Tests.Users.Queries
//{
//    [TestClass]
//    public class AuthenticateUserQuery_ExecuteShould : BaseTest
//    {
//        private readonly AuthenticateUserQuery _authenticateUserQuery;

//        public AuthenticateUserQuery_ExecuteShould()
//        {
//            _authenticateUserQuery = new AuthenticateUserQuery(RepositoryContainer.User);
//        }

//        [TestMethod]
//        public void ReturnSuccessWithValidCredentials()
//        {
//            var response = _authenticateUserQuery.Execute(new AuthenticateUserRequest
//            {
//                Username = "jstratman33",
//                Password = "password"
//            });

//            Assert.IsTrue(response.IsSuccess);
//        }

//        [TestMethod]
//        public void ReturnFailureWithInvalidCredentials()
//        {
//            var response = _authenticateUserQuery.Execute(new AuthenticateUserRequest
//            {
//                Username = "jstratman33",
//                Password = "this-is-the-wrong-password"
//            });

//            Assert.IsFalse(response.IsSuccess);
//        }
//    }
//}