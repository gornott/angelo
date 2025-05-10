namespace FiveCast
{
    internal static class IconHandler
    {
        public static Dictionary<string, string> iconMapping = new Dictionary<string, string>()
        {
            {"wsymbol_0001_sunny", "clear_day"},
            {"wsymbol_0002_sunny_intervals", "cloudy_1_day"},
            {"wsymbol_0003_white_cloud", "cloudy"},
            {"wsymbol_0004_black_low_cloud", "cloudy"},
            {"wsymbol_0006_mist", "fog"},
            {"wsymbol_0007_fog", "fog"},
            {"wsymbol_0008_clear_sky_night", "clear_night"},
            {"wsymbol_0009_light_rain_showers", "rainy_1"},
            {"wsymbol_0010_heavy_rain_showers", "rainy_1"},
            {"wsymbol_0011_light_snow_showers", "snowy_1"},
            {"wsymbol_0012_heavy_snow_showers", "snowy_3"},
            {"wsymbol_0013_sleet_showers", "snow_and_sleet_mix"},
            {"wsymbol_0016_thundery_showers", "scattered_thunderstorms"},
            {"wsymbol_0017_cloudy_with_light_rain", "rainy_1"},
            {"wsymbol_0018_cloudy_with_heavy_rain", "rainy_3"},
            {"wsymbol_0019_cloudy_with_light_snow", "snowy_1"},
            {"wsymbol_0020_cloudy_with_heavy_snow", "snowy_3"},
            {"wsymbol_0021_cloudy_with_sleet", "snow_and_sleet_mix"},
            {"wsymbol_0024_thunderstorms", "scattered_thunderstorms"},
            {"wsymbol_0025_light_rain_showers_night", "rainy_1_night"},
            {"wsymbol_0026_heavy_rain_showers_night", "rainy_1_night"},
            {"wsymbol_0027_light_snow_showers_night", "snowy_1_night"},
            {"wsymbol_0028_heavy_snow_showers_night", "snowy_3_night"},
            {"wsymbol_0029_sleet_showers_night", "snow_and_sleet_mix"},
            {"wsymbol_0032_thundery_showers_night", "scattered_thunderstorms_night"},
            {"wsymbol_0033_cloudy_with_light_rain_night", "rainy_1_night"},
            {"wsymbol_0034_cloudy_with_heavy_rain_night", "rainy_1_night"},
            {"wsymbol_0035_cloudy_with_light_snow_night", "snowy_1_night"},
            {"wsymbol_0036_cloudy_with_heavy_snow_night", "snowy_1_night"},
            {"wsymbol_0037_cloudy_with_sleet_night", "snow_and_sleet_mix"},
            {"wsymbol_0040_thunderstorms_night", "scattered_thunderstorms_night"},
        };

        public static string GetIconURI(string oldURI)
        {
            int lastSlashPos = oldURI.LastIndexOf('/');
            string key = oldURI.Substring(lastSlashPos + 1, oldURI.Length - lastSlashPos - 5);
            string? localFileName = iconMapping.GetValueOrDefault(key);
            return $"{localFileName}.png";
        }
    }
}
