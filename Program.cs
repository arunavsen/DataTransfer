using DataTransfer.Models.Receiver;
using DataTransfer.Models.Sender;
using Microsoft.EntityFrameworkCore;

SenderDBContext senderDBContext = new SenderDBContext();
ReceiverDBContext receiverDBContext = new ReceiverDBContext();

System.Net.ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

#region 1
//// Retrieve data from RegBriefDB
//var briefs = senderDBContext.Brief
//    .Include(b => b.BriefCountryMaps)
//        .ThenInclude(bcm => bcm.TaxBriefContents)
//    .Include(b => b.BriefCountryMaps)
//        .ThenInclude(bcm => bcm.TpaBriefContents)
//    .Include(b => b.BriefCountryMaps)
//        .ThenInclude(bcm => bcm.WtaBriefContents)
//    .ToList();



//// Insert data into NestDB2021
//foreach (var brief in briefs)
//{
//    // Create Briefing record
//    var briefing = new Briefing
//    {
//        PublishDate = brief.PublishDate,
//        Year = brief.Year,
//        Month = brief.Month
//    };
//    receiverDBContext.Briefings.Add(briefing);

//    // Create Story records for each BriefCountryMap
//    foreach (var briefCountryMap in brief.BriefCountryMaps)
//    {
//        var story = new Story
//        {
//            Title = briefCountryMap.CountryName,
//            RegFollowerLink = brief.Link,
//            Briefing = briefing
//        };
//        receiverDBContext.Stories.Add(story);

//        // Create WtaStory records
//        foreach (var wtaBriefContent in briefCountryMap.WtaBriefContents)
//        {
//            var wtaStory = new WtaStory
//            {
//                CountryCode = briefCountryMap.CountryName,
//                Story = story
//            };
//            receiverDBContext.WtaStories.Add(wtaStory);
//        }

//        // Create TpaStory records
//        foreach (var tpaBriefContent in briefCountryMap.TpaBriefContents)
//        {
//            var tpaStory = new TpaStory
//            {
//                CountryCode = briefCountryMap.CountryName,
//                Story = story
//            };
//            receiverDBContext.TpaStories.Add(tpaStory);
//        }

//        // Create TaxStory records
//        foreach (var taxBriefContent in briefCountryMap.TaxBriefContents)
//        {
//            var taxStory = new TaxStory
//            {
//                CountryCode = briefCountryMap.CountryName,
//                Story = story
//            };
//            receiverDBContext.TaxStories.Add(taxStory);
//        }
//    }
//}

//// Save changes to NestDB2021
//receiverDBContext.SaveChanges();

#endregion

//using (var regBriefDbContext = new SenderDBContext(optionsRegBriefDB)) // Connect to RegBriefDB
//{
//    var briefs = regBriefDbContext.Briefs.AsEnumerable(); // Retrieve data from Briefs table
//                                                          // Similarly retrieve data from other tables

//    using (var nestDbContext = new NestDbContext(optionsNestDB2021)) // Connect to NestDB2021
//    {
//        foreach (var brief in briefs)
//        {
//            var briefing = new Briefing // Map the data to the corresponding class in NestDB2021
//            {
//                PublishDate = brief.PublishDate,
//                Year = brief.Year,
//                Month = brief.Month,
//                BriefingType = null // set appropriate value for BriefingType
//            };
//            nestDbContext.Briefings.Add(briefing); // Add the data to NestDB2021
//            foreach (var briefCountryMap in brief.BriefCountryMaps)
//            {
//                var story = new Story
//                {
//                    Briefing = briefing,
//                    Title = null, // set appropriate value for Title
//                    ShortStory = null, // set appropriate value for ShortStory
//                    LongStory = null, // set appropriate value for LongStory
//                    RegFollowerLink = null // set appropriate value for RegFollowerLink
//                };
//                nestDbContext.Stories.Add(story);
//                foreach (var taxBriefContent in briefCountryMap.TaxBriefContents)
//                {
//                    var taxStory = new TaxStory
//                    {
//                        Story = story,
//                        CountryCode = null // set appropriate value for CountryCode
//                    };
//                    nestDbContext.TaxStories.Add(taxStory);
//                }
//                // Similarly add data to others tables
//            }
//        }
//        nestDbContext.SaveChanges(); // Save changes to NestDB2021 database
//    }
//}

var tt = "";