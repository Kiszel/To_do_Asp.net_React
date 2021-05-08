using Business_Logic_Layer.Handlers.BoardHandler;
using Business_Logic_Layer.Queries;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repositories;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTest_Todo_App
{
    public class BoardUnitTests
    {
        [Fact]
        public async void GetBoardTest()
        {
            var TestBoard = new List<Board>();
            var b = new Board();
            b.Id = 0;
            b.Title = "Board 0";
            b.Todos = new List<Todo>();
            TestBoard.Add(b);
            var b2 = new Board();
            b2.Id = 1;
            b2.Title = "Board 1";
            b2.Todos = new List<Todo>();
            TestBoard.Add(b2);

            var mediator = new Mock<IMediator>();
            var mockBoardRepository = new Mock<IBoardRepository>();


            mockBoardRepository.Setup(mr => mr.GetAllEntityAsync()).ReturnsAsync(TestBoard);

            mockBoardRepository.Setup(mr => mr.GetEntityAsync(
                It.IsAny<int>())).ReturnsAsync((int i) => TestBoard.Find(
                x => x.Id == i));

            var query = new GetBoardQuery();

            query.Id = 0;
            var handler = new GetBoardHandler(mockBoardRepository.Object);
            var handle = await handler.Handle(query,new System.Threading.CancellationToken());

            Assert.Equal(handle, b);

        }
    }
}
