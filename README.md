# My Journey

A responsive, static storybook made with HTML, CSS, and vanilla JavaScript. A Windows desktop version is also included as a C# WPF solution, with the site hosted inside WebView2.

## Run the WPF desktop app

1. Install Visual Studio with the **.NET desktop development** workload (or install the .NET 8 SDK and use `dotnet`).
2. Open `MyJourney.sln` in Visual Studio.
3. Let NuGet restore packages, then run the `MyJourney.Desktop` project.

The WPF project copies the complete website and `assets` folder beside the app during build, so the photos and video are available offline. The first run requires the Microsoft Edge WebView2 Runtime, which is installed on most Windows 10/11 PCs. The website can still be opened directly by opening `index.html` in a browser.

## Transfer the project to another location

Copy or zip the **entire `sowmya-journey` folder**, including `assets`, `desktop`, and `MyJourney.sln`. Extract it at the destination, then open `MyJourney.sln`. Do not copy only the `.sln` file: it references the WPF project and website assets using relative paths. If sending it to another person, they will need Visual Studio/.NET and the WebView2 Runtime to run the desktop app.

## Open the book

Open `index.html` in a browser. For the most reliable local video and image behavior, serve the folder with a static file server such as VS Code Live Server or `python -m http.server 8000` and visit `http://localhost:8000`.

## Add or change photos

Put photos in the matching category folder under `assets/images/`, then list every filename in that category's `photos` array in `data.js`. Each category has a small custom `puzzle.svg` illustration used by its six-piece puzzle. All categories start locked on each fresh open; completing that category's puzzle unlocks its scrapbook for the current visit. Closing the book or reloading resets all category locks. Clicking a scrapbook photo opens a separate book page with that single photo, and the book's Previous/Next arrows browse the remaining photos in that category.

```text
assets/
  images/
    me/
    family/
    friends/
    trips/
    festivals/
    photography/
    office/
  video/
    hi.mp4
  music/                 # optional: soft-piano.mp3 for the music toggle
index.html
style.css
puzzle.css
aesthetic.css
book.css
album.css
transitions.css
cover-layout.css
app.js
data.js
```

The downloaded video is installed as `assets/video/hi.mp4`. It starts muted because browsers block autoplay with sound; use the sound control on the opening spread to unmute. Each category is a dedicated book spread with scrapbook photo layouts and its own puzzle gate. The book has animated opening and closing covers, plus 3D page turns between spreads and individual photo pages.
