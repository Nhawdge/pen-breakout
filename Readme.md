# Pen Breakout!

A submissions for [Jame Gam #7](https://itch.io/jam/mini-jame-gam-7) by @Nhawdge

Everything in this project has been done by me. Here's the tools I used.

* Images created made with Krita and knock off brand graphic tablet.
* Audio created with [Chrome Experiments Song Maker](https://musiclab.chromeexperiments.com/Song-Maker)
* Code written in C# (.net6) with [Raylib-cs](https://github.com/ChrisDill/Raylib-cs)
* Code pattern is Entity-Component-Systems, and [available here](https://github.com/Nhawdge/pen-breakout)

I hope to finish it after the Jame Gam, but the ending time is too early in my timezone

## Build Note

dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeAllContentForSelfExtract=true

