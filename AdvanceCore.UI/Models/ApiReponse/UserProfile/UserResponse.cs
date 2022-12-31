using Newtonsoft.Json;

namespace AdvanceCore.UI.Models.ApiReponse.UserProfile;

public record UserResponse(
    [JsonProperty("id")]
    string Id,
    [JsonProperty("firstName")]
    string FirstName,
    [JsonProperty("lastName")]
    string LastName,
    [JsonProperty("userName")]
    string UserName,
    [JsonProperty("email")]
    string Email,
    [JsonProperty("phoneNumber")]
    string PhoneNumber,
    [JsonProperty("emailConfirmed")]
    bool EmailConfirmed,
    [JsonProperty("twoFactorEnabled")]
    bool TwoFactorEnabled,
    [JsonProperty("createdAtUtc")]
    string CreatedAtUtc
    );


//"firstName": "Ndivhuwo",
//        "lastName": "Khabubu",
//        "organizations": null,
//        "createdAtUtc": "2022-12-31T11:15:00.542113",
//        "id": "ec5558bf-275e-4d6a-a7ec-8e61ed1fb359",
//        "userName": "khabubu@gmail.com",
//        "normalizedUserName": "KHABUBU@GMAIL.COM",
//        "email": "khabubu@gmail.com",
//        "normalizedEmail": "KHABUBU@GMAIL.COM",
//        "emailConfirmed": false,
//        "passwordHash": "AQAAAAEAACcQAAAAEDhqgBSJvo8NAC0+hfuypdKqy6HvHzH+hVB+Z0+xcOD7vY76wRSCs3utZRmoMfbcXA==",
//        "securityStamp": "HBZL33VFRL6AULKOLGLTYXIEWHJ2F6AN",
//        "concurrencyStamp": "ecc05ec8-6112-4a7b-87d2-f0468fe7d7c3",
//        "phoneNumber": null,
//        "phoneNumberConfirmed": false,
//        "twoFactorEnabled": false,
//        "lockoutEnd": null,
//        "lockoutEnabled": true,
//        "accessFailedCount": 0
