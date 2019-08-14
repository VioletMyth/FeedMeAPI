/*using FeedMe.Controllers;
using FeedMe.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace FeedMeAPIUnitTests
{
    [TestClass]
    class DetailsControllerUnitTests
    {
        public static readonly DbContextOptions<FeedMeContext> options
        = new DbContextOptionsBuilder<FeedMeContext>()
        .UseInMemoryDatabase(databaseName: "testDatabase")
        .Options;
        public static IConfiguration configuration = null;
        public static readonly IList<string> memeTitles = new List<string> { "dankMeme", "dankerMeme" };




        public static readonly IList<Detail> details = new List<Detail>
        {
            new Detail()
            {
                Title = "Spaghetti"
            },
            new Detail()
            {
                Title = "Ramen"
            }
        };

         [TestInitialize]
         public void SetupDb()
        {
            using (var context = new FeedMeContext(options))
            {
                context.Detail.Add(details[0]);
                context.Detail.Add(details[1]);
                context.SaveChanges();

            }
        }

        [TestCleanup]
        public void ClearDb()
        {
            using(var context = new FeedMeContext(options))
            {
                context.Detail.RemoveRange(context.Detail);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public async Task TestGetSuccessfully()
        {
            using (var context = new FeedMeContext(options))
            {
                DetailsController detailsController = new DetailsController(context);
                ActionResult<IEnumerable<Detail>> result = await detailsController.GetDetail();

                Assert.IsNotNull(result);
            }
        }

        [TestMethod]
        public async Task TestPutDetailNoContentStatusCode()
        {
            using (var context = new FeedMeContext(options))
            {
                string newPhrase = "this is now a different phrase";
                Detail transcription1 = context.Detail.Where(x => x.Title == details[0].Title).Single();
                transcription1.Title = newPhrase;

                DetailsController transcriptionsController = new DetailsController(context, configuration);
                IActionResult result = await transcriptionsController.PutDetail(transcription1.Id, transcription1) as IActionResult;

                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(NoContentResult));
            }
        }

        [TestMethod]
        public async Task UploadFile()
        {
            using (var context = new FeedMeContext(options))
            {
                // Given
                string title = "putMeme";
                Detail memeItem1 = context.Detail.Where(x => x.Title == details[0].Title).Single();
                memeItem1.Title = title;

                // When
                DetailsController memeController = new DetailsController(context, configuration);
                IActionResult result = await memeController.PutDetail(memeItem1.Id, memeItem1) as IActionResult;

                // Then
                memeItem1 = context.Detail.Where(x => x.Title == title).Single();
            }
        }


    }

}*/

using FeedMe.Controllers;
using FeedMe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using FeedMe.Model;

namespace FeedMeAPIUnitTests
{
    [TestClass]
    public class FeedMeAPIUnitTests
    {

        public static readonly DbContextOptions<FeedMeContext> options
        = new DbContextOptionsBuilder<FeedMeContext>()
        .UseInMemoryDatabase(databaseName: "testDatabase")
        .Options;
        public static IConfiguration configuration = null;
        public static readonly IList<string> memeTitles = new List<string> { "dankMeme", "dankerMeme" };

        [TestInitialize]
        public void SetupDb()
        {
            using (var context = new FeedMeContext(options))
            {
                Detail memeItem1 = new Detail()
                {
                    Title = memeTitles[0]
                };

                Detail memeItem2 = new Detail()
                {
                    Title = memeTitles[1]
                };

                context.Detail.Add(memeItem1);
                context.Detail.Add(memeItem2);
                context.SaveChanges();
            }
        }

        [TestCleanup]
        public void ClearDb()
        {
            using (var context = new FeedMeContext(options))
            {
                context.Detail.RemoveRange(context.Detail);
                context.SaveChanges();
            };
        }

        [TestMethod]
        public async Task TestPutMemeItemNoContentStatusCode()
        {
            using (var context = new FeedMeContext(options))
            {
                // Given
                string title = "putMeme";
                Detail memeItem1 = context.Detail.Where(x => x.Title == memeTitles[0]).Single();
                memeItem1.Title = title;

                // When
                DetailsController memeController = new DetailsController(context, configuration);
                IActionResult result = await memeController.PutDetail(memeItem1.Id, memeItem1) as IActionResult;

                // Then
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(NoContentResult));
            }
        }

        [TestMethod]
        public async Task TestPutMemeItemUpdate()
        {
            using (var context = new FeedMeContext(options))
            {
                // Given
                string title = "putMeme";
                Detail memeItem1 = context.Detail.Where(x => x.Title == memeTitles[0]).Single();
                memeItem1.Title = title;

                // When
                DetailsController memeController = new DetailsController(context, configuration);
                IActionResult result = await memeController.PutDetail(memeItem1.Id, memeItem1) as IActionResult;

                // Then
                memeItem1 = context.Detail.Where(x => x.Title == title).Single();
            }
        }

        [TestMethod]
        public async Task TestGetSuccessfully()
        {
            using (var context = new FeedMeContext(options))
            {
                DetailsController detailsController = new DetailsController(context, configuration);
                ActionResult<IEnumerable<Detail>> result = await detailsController.GetDetail();

                Assert.IsNotNull(result);
            }
        }

    }
}
