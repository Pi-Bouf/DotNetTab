namespace TabSystem.Tab
{
    class TabFactory
    {
        public static Tab createNewTab()
        {
            return generateTab("http://localhost", "Google");
        }

        public static Tab createNewTab(string url, string title)
        {
            return generateTab(url, title);
        }

        public static Tab generateTab(string url, string title)
        {
            return new Tab(url, title);
        }
    }
}
