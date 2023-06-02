using DataTransfer.Common;
using DataTransfer.Models.Receiver;
using DataTransfer.Models.Sender;
using Microsoft.EntityFrameworkCore;

SenderDBContext senderDBContext = new SenderDBContext();
ReceiverDBContext receiverDBContext = new ReceiverDBContext();

System.Net.ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;


// Retrieve data from RegBriefDB
var briefs = senderDBContext.Brief
    .Include(b => b.BriefCountryMaps)
        .ThenInclude(bcm => bcm.TaxBriefContents)
    .Include(b => b.BriefCountryMaps)
        .ThenInclude(bcm => bcm.TpaBriefContents)
    .Include(b => b.BriefCountryMaps)
        .ThenInclude(bcm => bcm.WtaBriefContents)
    .ToList().Where(x => x.Id == 7830);

var countries = senderDBContext.Country.ToList();


// Insert data into NestDB2021
foreach (var brief in briefs)
{
    // Create Briefing record
    var briefing = new Briefing
    {
        PublishDate = brief.PublishDate,
        Year = brief.Year,
        Month = brief.Month
    };
    foreach (var briefCountryMap in brief.BriefCountryMaps)
    {
        if (briefCountryMap.TpaBriefContents.Count() > 0)
        {
            briefing.BriefingType = RegBriefingType.TpaBriefing;
            receiverDBContext.Briefings.Add(briefing);
            receiverDBContext.SaveChanges();

            foreach (var tpaBriefContent in briefCountryMap.TpaBriefContents)
            {
                var story = new Story
                {
                    Title = tpaBriefContent.Title,
                    ShortStory = tpaBriefContent.Content,
                    LongStory = "",
                    RegFollowerLink = tpaBriefContent.RegFollowerLink,
                };
                receiverDBContext.Stories.Add(story);

                var tpaStory = new TpaStory
                {
                    CountryCode = countries.FirstOrDefault(x => x.Name == briefCountryMap.CountryName).Code,
                    StoryId = story.Id,
                };
                receiverDBContext.TpaStories.Add(tpaStory);
                receiverDBContext.SaveChanges();
            }
        }
        else if (briefCountryMap.WtaBriefContents.Count() > 0)
        {
            briefing.BriefingType = RegBriefingType.WtaBriefing;
            receiverDBContext.Briefings.Add(briefing);
            //receiverDBContext.SaveChanges();
            foreach (var wtaBriefContent in briefCountryMap.WtaBriefContents)
            {
                var story = new Story
                {
                    Title = wtaBriefContent.Title,
                    ShortStory = wtaBriefContent.Content,
                    LongStory = "",
                    RegFollowerLink = wtaBriefContent.RegFollowerLink,
                };
                receiverDBContext.Stories.Add(story);
                //receiverDBContext.SaveChanges();

                var wtoStory = new WtaStory
                {
                    CountryCode = !string.IsNullOrEmpty(briefCountryMap.CountryName) ?  countries.FirstOrDefault(x => x.Name == briefCountryMap.CountryName)?.Code : null,
                    Story = story,
                };
                receiverDBContext.WtaStories.Add(wtoStory);
                //receiverDBContext.SaveChanges();
            }
        }
        else
        {
            briefing.BriefingType = RegBriefingType.TaxBriefing;
            receiverDBContext.Briefings.Add(briefing);
            foreach (var taxBriefContent in briefCountryMap.TaxBriefContents)
            {
                var story = new Story
                {
                    Title = taxBriefContent.CountryName,
                    ShortStory = taxBriefContent.CountryName,
                    LongStory = "",
                    RegFollowerLink = "",
                };
                receiverDBContext.Stories.Add(story);
                receiverDBContext.SaveChanges();

                var taxStory = new TaxStory
                {
                    CountryCode = countries.FirstOrDefault(x => x.Name == briefCountryMap.CountryName).Code,
                    StoryId = story.Id,
                };
                receiverDBContext.TaxStories.Add(taxStory);
                receiverDBContext.SaveChanges();
            }
        }
    }
}

// Save changes to NestDB2021
receiverDBContext.SaveChanges();

#region 1
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

