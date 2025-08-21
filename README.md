# Desktop Assistant (WPF)

A simple WPF application designed as a home-style desktop.

## Features
- Real-time display of date, time, and day of the week.
- Wireless mouse simulation with battery level indicator:
  - shows percentage value;
  - circular progress ring changes color depending on the charge.
- Three quick-access buttons:
  - open the project folder,
  - open the log file,
  - open notes (Notepad).
- Additional buttons:
  - open a weather forecast website,
  - open a currency exchange rates website.
- A mini-window with a random quote selected from a predefined list.

## Tests
- **GetRandomQuote_ShouldReturnNonNullOrEmptyQuote**
  Ensures `GetRandomQuote()` returns a non-null and non-empty string.
- **GetRandomQuote_ShouldReturnQuoteFromList**
  Ensures the returned quote is present in the predefined list of quotes.
- **Log_ShouldAddEntry**
  Ensures `Log("Test message")` adds an entry to the log list.
- **SaveToJson_ShouldCreateFile**
  Ensures that after logging and calling `SaveToJson()`, a file is created and exists on disk.

## Technologies
- C#
- WPF (.NET)

## Screenshots

Main view of the application:
![Screenshot](https://github.com/CurlyLikee/UI-Playground/blob/main/screenshot.png)
