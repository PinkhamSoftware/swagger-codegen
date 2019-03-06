using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using HomesEngland.Gateway;
using HomesEngland.UseCase.CreateAsset.Models;

namespace TestHelper
{
    public static class TestData
    {
        public static class Domain
        {
            public static DocumentEntity GenerateAsset()
            {
                var random = new Random(0);

                var faker = new Faker("en");
                var completionDateForHpiStart = faker.Date.Soon(random.Next(1, 15));
                var imsActualCompletionDate = faker.Date.Soon(random.Next(30, 90));
                var imsExpectedCompletionDate = faker.Date.Soon(random.Next(15, 90));
                var hopCompletionDate = faker.Date.Soon(random.Next(15, 90));
                var differenceFromImsExpectedCompletionToHopCompletionDate =
                    (imsExpectedCompletionDate.Date - hopCompletionDate).Days;


                var appliedOrLimited = new List<string> {"Applied", "Limited"};
                var houseType = new List<string> { "Semi-Detached", "Detached" };
                var holdTypes = new List<string> { "Freehold", "Leasehold" };


                var generatedAsset = new Faker<DocumentEntity>("en");

                return generatedAsset;
            }
        }

        public static class UseCase
        {
            public static CreateDocumentRequest GenerateCreateAssetRequest()
            {

                var generatedAsset = new Faker<CreateDocumentRequest>("en");
                    
                return generatedAsset;
            }
        }

        public static class PostCodes
        {
            private static List<string> _postCodes = new List<string>
            {
                "AB1 0UD",
                "AB1 0UE",
                "AB1 0UJ",
                "AB1 0UL",
                "AB1 0UN",
                "AB1 0UP",
                "AB1 0UQ",
                "AB1 0UR",
                "AB1 0US",
                "AB1 0UT",
                "AB1 0UX",
                "AB1 0WA",
                "AB1 0WB",
                "AB1 0WD",
                "AB1 0WE",
                "AB1 0WF",
                "AB1 0WG",
                "AB1 0WH",
                "AB1 0WN",
                "AB1 0XA",
                "AB1 0XB",
                "AB1 0XD",
                "AB1 0XE",
                "AB1 0XJ",
                "AB1 0XL",
                "AB1 0XN",
                "AB1 0XP",
                "AB1 0XQ",
                "AB1 0XR",
                "AB1 0XU",
                "AB1 0YA",
                "CV8 1LL",
                "CV8 1LN",
                "CV8 1LP",
                "CV8 1LQ",
                "CV8 1LR",
                "CV8 1LS",
                "CV8 1LT",
                "CV8 1LU",
                "CV8 1LW",
                "CV8 1LX",
                "CV8 1LY",
                "CV8 1LZ",
                "CV8 1NA",
                "CV8 1NB",
                "CV8 1ND",
                "CV8 1NE",
                "CV8 1NF",
                "CV8 1NG",
                "CV8 1NH",
                "CV8 1NJ",
                "CV8 1NL",
                "CV8 1NN",
                "CV8 1NP",
                "CV8 1NQ",
                "CV8 1NR",
                "CV8 1NS",
                "CV8 1NT",
                "CV8 1NU",
                "CV8 1NW",
                "CV8 1NX",
                "CW1 3DE",
                "CW1 3DF",
                "CW1 3DG",
                "CW1 3DH",
                "CW1 3DJ",
                "CW1 3DL",
                "CW1 3DN",
                "CW1 3DP",
                "CW1 3DQ",
                "CW1 3DR",
                "CW1 3DS",
                "CW1 3DT",
                "E6 1RX",
                "E6 1RY",
                "E6 1RZ",
                "E6 1SA",
                "E6 1SB",
                "E6 1SD",
                "E6 1SE",
                "E6 1SF",
                "E6 1SG",
                "E6 1SH",
                "E6 1SJ",
                "E6 1SL",
                "E6 1SN",
                "G72 7XE",
                "G72 7XF",
                "G72 7XG",
                "G72 7XH",
                "G72 7XJ",
                "G72 7XL",
                "G72 7XN",
                "G72 7XP",
                "G72 7XQ",
                "GL12 8TX",
                "GL12 8TY",
                "GL12 8TZ",
                "GL12 8UA",
                "GL12 8UB",
                "GL12 8UD",
                "GL12 8UE",
                "GL12 8UF",
                "GL12 8UG",
                "GL12 8UH",
                "GL12 8UJ",
                "GL12 8UL",
                "GL12 8UN",
                "GL12 8UP",
                "GL12 8UQ",
                "GL12 8UR",
                "GL12 8US",
                "GL12 8UT",
                "GL12 8UU",
                "GL4 6BD",
                "GL4 6BE",
                "GL4 6BG",
                "GL4 6BH",
                "GL4 6BJ",
                "GL4 6BL",
                "GL4 6BN",
                "GL4 6BP",
                "GL4 6BQ",
                "GL4 6BS",
                "GL4 6BT",
                "GL4 6BU",
                "GL4 6BW",
                "GL4 6BX",
                "GL4 6DA",
                "GL4 6DG",
                "GL4 6DT",
                "HX1 4QN",
                "HX1 4QP",
                "HX1 4QQ",
                "HX1 4QR",
                "HX1 4QS",
                "HX1 4QT",
                "HX1 4QU",
                "HX1 4QW",
                "HX1 4QX",
                "HX1 4QY",
                "HX1 4QZ",
                "HX1 4RA",
                "HX1 4RB",
                "HX1 4RD",
                "HX1 4RE",
                "HX1 4RF",
                "HX1 4RG",
                "ME5 9FB",
                "ME5 9FD",
                "ME5 9FE",
                "ME5 9FF",
                "ME5 9FZ",
                "PO4 8FW",
                "PO4 8GA",
                "PO4 8GB",
                "PO4 8GD",
                "PO4 8GE",
                "PO4 8GR",
                "PO4 8GS",
                "SP1 2PH",
                "SP1 2PJ",
                "SP1 2PL",
                "SP1 2PN",
                "SP1 2PP",
                "SP1 2PQ",
                "SP1 2PR",
                "SP1 2PS",
                "SP1 2PT",
                "SP1 2PU",
                "SP1 2PW",
                "SP1 2PX",
                "TD5 7TZ",
                "TD5 7UA",
                "TD5 7UB",
                "TD5 7UD",
                "TD5 7UE",
                "TD5 7UF",
                "TF3 2JU",
                "TF3 2JW",
                "TF3 2JX",
                "TF3 2JY",
                "TF3 2JZ",
                "TF3 2LA",
                "TF3 2LB",
                "TF3 2LD",
                "TF3 2LE",
                "TF3 2LF",
                "TF3 2LG",
                "TF3 2LH",
                "W1U 7NA",
                "W1U 7NB",
                "W1U 7ND",
                "W1U 7NE",
                "W1U 7NF",
                "W1U 7NG",
                "W1U 7NH",
                "W1U 7NN",
                "W1U 7NP",
                "WS13 6JH",
                "WS13 6JJ",
                "WS13 6JL",
                "WS13 6JN",
                "WS13 6JP",
                "WS13 6JQ",
                "WS13 6JR",
                "WS13 6JS",
                "WS13 6JT",
                "WS13 6JU",
                "WS13 6JW",
            };

            public static string RandomUkPostCode()
            {
                var seed = new Random(DateTime.UtcNow.Millisecond);
                var index = seed.Next(0, _postCodes.Count -1);
                var postCode = _postCodes.ElementAt(index);
                return postCode;
            }
        }
    }
}
