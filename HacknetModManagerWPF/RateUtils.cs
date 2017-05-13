using System.Windows;
using Octokit;

namespace HacknetModManager {
    public static class RateUtils {
        public static RateLimit GetRateLimit(GitHubClient client) {
            return client.Miscellaneous.GetRateLimits().Result.Rate;
        }

        public static string GetFormattedResetTime(GitHubClient client, bool twentyFourHour) {
            return GetFormattedResetTime(GetRateLimit(client), twentyFourHour);
        }

        public static string GetFormattedResetTime(RateLimit limit, bool twentyFourHour) {
            if(twentyFourHour)
                return limit.Reset.LocalDateTime.ToString("H:mm:ss");
            else
                return limit.Reset.LocalDateTime.ToString("h:mm:ss tt");
        }

        public static void ShowRateErrorMessage(GitHubClient client, bool twentyFourHour) {
            MessageBox.Show("You have reached your rate limit. You can make requests again at "
                + GetFormattedResetTime(client, twentyFourHour) + ".", "Rate Limit Exceeded");
        }
    }
}
