# Ruutu

Small piece of software that opens [Ruutu.fi](http://www.ruutu.fi/) videos in VLC.

![Screenshot of the software](Screenshot.gif)

## Startup with Linux
This application works also with Linux, download [Mono](http://www.mono-project.com/), and run `mono Ruutu.exe` in command line

## API
```csharp
using Ruutu.API;

class Example
{
	static void Main()
	{
		Uri videoUrl = new Uri("http://www.ruutu.fi/video/1234567");

		RuutuVideo.Open(videoUrl);
	}
}
```

## License

```
ISC License

Copyright (c) 2017 Elias Ojala

Permission to use, copy, modify, and/or distribute this software for any
purpose with or without fee is hereby granted, provided that the above
copyright notice and this permission notice appear in all copies.

THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN
ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF
OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.
```