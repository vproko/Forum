using AutoMapper;
using Forum.Dto.Models;
using Forum.Services.Interfaces;
using Forum.ViewModels.ViewModels;
using Forum.WebApp.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Forum.Tests
{
    public class UnitTests
    {

        [Fact]
        public async Task LoginAsyncTest_CorrectInput_ExpectingToBeRedirected()
        {
            // Arrange
            var loginModel = new Mock<LoginViewModel>();
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(service => service.LogInAsync(It.IsAny<LoginViewModel>())).ReturnsAsync(true);
            var mockAutoMapper = new Mock<IMapper>();
            var mockEnvironment = new Mock<IWebHostEnvironment>();
            var userController = new UserController(mockUserService.Object, mockAutoMapper.Object, mockEnvironment.Object);

            // Act
            var result = await userController.LoginAsync(loginModel.Object);

            // Assert
            var viewResult = Assert.IsAssignableFrom<RedirectToActionResult>(result);
            mockUserService.Verify(service => service.LogInAsync(loginModel.Object), Times.Once);
        }

        [Fact]
        public async Task LoginAsyncTest_IncorrectInput_ExpectingRedirectionToFail()
        {
            // Arrange
            var loginModel = new Mock<LoginViewModel>();
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(service => service.LogInAsync(It.IsAny<LoginViewModel>())).ReturnsAsync(true);
            var mockAutoMapper = new Mock<IMapper>();
            var mockEnvironment = new Mock<IWebHostEnvironment>();
            var userController = new UserController(mockUserService.Object, mockAutoMapper.Object, mockEnvironment.Object);
            userController.ModelState.AddModelError("key", "errorMessage");

            // Act
            var result = await userController.LoginAsync(loginModel.Object);

            // Assert
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
            mockUserService.Verify(service => service.LogInAsync(loginModel.Object), Times.Never);
        }

        [Fact]
        public async Task TestFindUserAsync_OnGivenId_ReturnsUser()
        {
            // Arrange
            var user = new Mock<UserDto>();
            var mockUserService = new Mock<IUserService>();
            var mockAutoMapper = new Mock<IMapper>();
            var mockEnvironment = new Mock<IWebHostEnvironment>();
            var userController = new UserController(mockUserService.Object, mockAutoMapper.Object, mockEnvironment.Object);

            // Act
            var actual = await userController.FindUserAsync(It.IsAny<Guid>());

            // Assert
            mockUserService.Verify(service => service.FindUserAsync(It.IsAny<Guid>()), Times.Once);
            Assert.NotNull(actual);
        }

        [Fact]
        public async Task TestViewCategories_ReturnsViewWithCategories()
        {
            // Arrange
            var mockCategoryService = new Mock<ICategoryService>();
            var mockUserService = new Mock<IUserService>();
            var mockAutoMapper = new Mock<IMapper>();
            var userController = new CategoryController(mockCategoryService.Object, mockUserService.Object, mockAutoMapper.Object);

            // Act
            var result = await userController.ViewCategoriesAsync();

            // Assert
            mockCategoryService.Verify(service => service.GetAllCategoriesAsync(1, 5), Times.Once);
            Assert.IsAssignableFrom<ViewResult>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task TestViewCategories_ReturnsAViewWithListOfCategoryViewModels()
        {
            // Arrange
            var mockCategoryService = new Mock<ICategoryService>();
            var mockUserService = new Mock<IUserService>();
            var mockAutoMapper = new Mock<IMapper>();
            var userController = new CategoryController(mockCategoryService.Object, mockUserService.Object, mockAutoMapper.Object);

            // Act
            var result = await userController.ViewCategoriesAsync();

            // Assert
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
            Assert.IsAssignableFrom<IEnumerable<CategoryViewModel>>(viewResult.ViewData.Model);
        }

        [Fact]
        public async Task TestSearchPostsAsync_IncorrectInput_Redirects()
        {
            // Arrange
            var mockPostService = new Mock<IPostService>();
            var mockUserService = new Mock<IUserService>();
            var mockAutoMapper = new Mock<IMapper>();
            var userController = new PostController(mockPostService.Object, mockUserService.Object, mockAutoMapper.Object);

            // Act
            var result = await userController.SearchPostsAsync("", It.IsAny<CancellationToken>(), 1, 5);

            // Assert
            var viewResult = Assert.IsAssignableFrom<RedirectToActionResult>(result);
            mockPostService.Verify(service => service.FindPostsAsync("", 1, 5, It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task TestSearchPostsAsync_CorrectInput_Redirects()
        {
            IList<PostDto> posts = new List<PostDto> { new PostDto() };
            CancellationTokenSource cts = new();
            CancellationToken token = cts.Token;
            var mockPostService = new Mock<IPostService>();
            mockPostService.Setup(service => service.FindPostsAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>())).ReturnsAsync(posts);
            var mockUserService = new Mock<IUserService>();
            var mockAutoMapper = new Mock<IMapper>();
            var userController = new PostController(mockPostService.Object, mockUserService.Object, mockAutoMapper.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext
                    {
                        User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, "username")
                        }, "someAuthTypeName"))
                    }
                }
            };

            // Act
            var result = await userController.SearchPostsAsync("test", token, 1, 5);

            // Assert
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
            Assert.IsAssignableFrom<IEnumerable<PostViewModel>>(viewResult.ViewData.Model);
            mockPostService.Verify(service => service.FindPostsAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task ViewThreadAsync_CorrectId_ExpctingRedirectToAction()
        {
            // Arrange
            var threadModel = new ThreadDto();
            var threadId = Guid.NewGuid();
            var userModel = new UserDto();
            var threadViewModel = new ThreadViewModel();
            var mockThredService = new Mock<IThreadService>();
            mockThredService.Setup(service => service.FindThreadWithRelatedDataAsync(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(threadModel);
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(service => service.FindUserAsync(It.IsAny<string>())).ReturnsAsync(userModel);
            var mockAutoMapper = new Mock<IMapper>();
            mockAutoMapper.Setup(mapper => mapper.Map<ThreadViewModel>(threadModel)).Returns(threadViewModel);
            var threadController = new ThreadController(mockThredService.Object, mockUserService.Object, mockAutoMapper.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext
                    {
                        User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, "username")
                        }, "someAuthTypeName"))
                    }
                }
            };

            // Act
            var result = await threadController.ViewThreadAsync(threadId);

            // Assert
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
            Assert.IsAssignableFrom<ThreadViewModel>(viewResult.ViewData.Model);
        }

        [Fact]
        public async Task ViewThreadAsync_IncorrectId_ExpctingRedirectToAction()
        {
            // Arrange
            var threadViewModel = new ThreadViewModel();
            var mockThredService = new Mock<IThreadService>();
            var mockUserService = new Mock<IUserService>();
            var mockAutoMapper = new Mock<IMapper>();
            var threadController = new ThreadController(mockThredService.Object, mockUserService.Object, mockAutoMapper.Object);

            // Act
            var result = await threadController.ViewThreadAsync(Guid.Empty);

            // Assert
            var viewResult = Assert.IsAssignableFrom<RedirectToActionResult>(result);
            mockThredService.Verify(service => service.FindThreadWithRelatedDataAsync(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>()), Times.Never);
            mockUserService.Verify(service => service.FindUserAsync(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task CreateThreadAsync_CorrectId_ExpctingRedirectToAction()
        {
            // Arrange
            var threadViewModel = new Mock<ThreadViewModel>();
            var mockThredService = new Mock<IThreadService>();
            mockThredService.Setup(service => service.CreateAsync(It.IsAny<ThreadViewModel>())).Verifiable();
            var mockUserService = new Mock<IUserService>();
            var mockAutoMapper = new Mock<IMapper>();
            var threadController = new ThreadController(mockThredService.Object, mockUserService.Object, mockAutoMapper.Object);

            // Act
            var result = await threadController.CreateThreadAsync(threadViewModel.Object, Guid.NewGuid(), 1, 5);

            // Assert
            var viewResult = Assert.IsAssignableFrom<RedirectToActionResult>(result);
            mockThredService.Verify(service => service.CreateAsync(threadViewModel.Object), Times.Once);
        }

    }

}
