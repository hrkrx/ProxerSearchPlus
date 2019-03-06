using System;

namespace ProxerSearchPlus.model.v1
{
    public class Error
    {
        public ErrorCode ErrorMessage { get; set; }
        public Error(string code)
            : this(int.Parse(code))
        { }

        public Error(int code)
        {
            ErrorMessage = (ErrorCode)(code);
        }

        public override string ToString() => Enum.GetName(typeof(ErrorCode), ErrorMessage) + " (" + (int)(ErrorMessage) + ")";
    }

    public enum ErrorCode
    {
        NoError = 0,
        UnknownError = 1,

        // Proxer API Errors
        APInotExisting = 1000,
        APIgotDeleted = 1001,
        APIclassNotExisting = 1002,
        APIfunctionNotExisting = 1003,
        APIkeyPermissionDenied = 1004,
        APIinvalidLoginToken = 1005,
        APIfunctionRestricted = 1006,
        APIproxerMaintenance = 1007,
        APImaintenance = 1008,
        APIipBlocked = 2000,
        APInewsRequestError = 2001,
        APIloginIncomplete = 3000,
        APIloginWrongCredentials = 3001,
        APInotificationsUserNotLoggedIn = 3002,
        APIuserInfoUserNotExisting = 3003,
        APIucpUserNotLoggedIn = 3004,
        APIucpCategoryDoesNotExist = 3005,
        APIucpInvalidID = 3006,
        APIinfoInvalidID = 3007,
        APIinfoSetUserInfoInvalidType = 3008,
        APIinfoSetUserInfoNotLoggedIn = 3009,
        APIinfoSetUserInfoAlreadyPresent = 3010,
        APIinfoSetUserInfoFavoritesFull = 3011,
        APIloginAlreadyLoggedIn = 3012,
        APIloginAnotherUserLoggedIn = 3013,
        APIuserAccessRestricted = 3014,
        APIlistCategoryDoesNotExist = 3015,
        APIlistMediaDoesNotExist = 3016,
        APImediaStyleDoesNotExist = 3017,
        APImediaEntryDoesNotExist = 3018,
        APImangaChapterDoesNotExist = 3019,
        APIanimeEpisodeDoesNotExist = 3020,
        APIanimeStreamDoesNotExist = 3021,
        APIucpEpisodeDoesNotExist = 3022,
        APImessagesUserIsNotLoggedIn = 3023,
        APImessagesInvalidConference = 3024,
        APImessagesInvalidOrMissingReason = 3025,
        APImessagesInvalidMissingMessage = 3026,
        APImessagesInvalidUser = 3027,
        APImessagesMaximumUsersReached = 3028,
        APImessagesInvalidOrMissingTopic = 3029,
        APImessagesAddAtLeastOneUser = 3030,
        APIchatInvalidRoom = 3031,
        APIchatPermissionDenied = 3032,
        APIchatInvalidMessage = 3033,
        APIchatNotLoggedIn = 3034,
        APIlistInvalidLanguage = 3035,
        APIlistInvalidType = 3036,
        APIlistInvalidID = 3037,
        APIuserTwoFactorAuthSecretKeyMissing = 3038,
        APIuserAccountExpired = 3039,
        APIuserAccountBanned = 3040,
        APIuserInternalError = 3041,
        APIappsEmptyStringWasSent = 3042,
        APIlistInvalidSubject = 3043,
        APIforumInvalidID = 3044,
        APIappsInvalidID = 3045,
        APIlistTopWasReset = 3046,
        APIuserAuthUserDoesNotExist = 3047,
        APIuserAuthCodeNeedsToBeOneHundredCharactersLong = 3048,
        APIuserAuthCodeAlreadyExisting = 3049,
        APIuserAuthCodeDoesNotExist = 3050,
        APIuserAuthCodeRejected = 3051,
        APIuserAuthCodeNotYetVerifiedByUser = 3052,
        APIuserAuthNameEmpty = 3053,
        APIuserAuthCodeAlreadyInUse = 3054,
        APIchatUserNotYetAllowedToChat = 3055,
        APIchatUserBlacklisted = 3056,
        APIchatMissingPermission = 3057,
        APIchatInvalidInput = 3058,
        APIforumAccessDenied = 3059,
        APIinfoDeletingOfCommentFailed = 3060,
        APIanimeStreamForGuestsNotAvailable = 3061
    }
}