# AHIF Academy

## Grobe Idee

Eine Lernapp für verschiedene Fächer mit angepassten Fragen und Aufgaben.

## Must-Have


- User Profiles
- Loginsystem
- Benutzerfreundliches und ansprechendes GUI
  - Mehrere Themes (Darkmode,...)
- Benutzerdefinierte Fragen (Durch Eingabe und Auswahl von Kategorien/Tags)
- Eigene Pages für die Fächer
- Verschiedene Aufgabentypen:
  - Karteikarten Englisch
  - Normale Matheaufgaben
  - Deutsch Fehler finden, Zeichensetzung,...


## Nice-To-Have

- Fragen nach Schulstufen filtern
- Mehr Fächer und Aufgabentypen
- Schöne Matheformeln
- User Profiles:
  - Achievement
  - Mit "Geld" Avatar bearbeiten/Minispiele spielen
- AHIF Pass (Battle Pass)
- Vorbereitete Lerndokumente
- Minigames

## Wont-Have

- Globale Datenbank
- Globales Loginsystem
- Online Multiplayer
- Mehrere Sprachen

## Aufteilung

### Arbeitsteilung

| Marlon                          | Ensar               |
| ------------------------------- | ------------------- |
| Klassen                         | GUI                 |
| User Profiles inkl. Statistiken | Login-System        |
| Mathe, Deutsch                  | Karteikarten        |
| Fragen organisieren             | Fragen organisieren |

### Grobe zeitliche Einteilung

| Zeitraum | Marlon                          | Ensar |
| -------- | ------------------------------- | ----- |
| Woche 1  | Klassen                         | GUI   |
| Woche 2  | Mathe und Deutsch               |       |
| Woche 3  | User Profiles inkl. Statistiken |       |
| Woche 4  | Nice-To-Haves                   |       |

## Klassen

- MultipleChoice
- YesNo 
- TextInput
- FlashCard
- User
- ChangeTheme

### MultipleChoice

```
@startuml
class MultipleChoice{
+ Subject: string
+ Text: string
+ Answers: string[4]
+ CorrectAnswer: string
+ MultipleChoice()
+ MultipleChoice(string text, string ans1, string ans2, string ans3, string ans4, char correctAnswer, string Subject)
+ Draw(Grid grid): void
+ ShuffleAnswers(): void
+ CheckAnswer(int index): void
}
@enduml
```

### YesNo

```
@startuml
class YesNo{
+ Subject: string
+ Text: string
+ CorrectAnswer: bool
+ YesNo()
+YesNo(string text, bool correctAnswer, string Subject)
+ Draw(Grid grid): void
+ CheckAnswer(int index): void
}
@enduml
```

### TextInput

```
@startuml
class TextInput{
+ Subject: string
+ Text: string
+ CorrectAnswer: string
+ WrongText: string
+ TextInput()
+ TextInput(string text, string CorrectAnswer, string WrongText, string Subject)
+ Draw(Grid grid): void
+ CheckAnswer(string answer): void
}
@enduml
```

### FlashCard

```
+ Subject: string
+ Group: id
+ FirstText: string
+ SecondText: string
+ Shown: bool
+ FlashCard(string first, string second, string Group, string Subject)
+ Draw(): void
```

### User

```
@startuml
class User{
+ Username: string
+ Password: string
+ QuestionsAnsweredMath: int
+ QuestionsAnsweredEnglish: int
+ QuestionsAnsweredGerman: int
+ QuestionsAnsweredCorrectMath: int
+ QuestionsAnsweredCorrectEnglish: int
+ QuestionsAnsweredCorrectGerman: int
+ StatisticsDraw()
}

### QuestionCollection
```
@startuml
class QuestionList{
- questions: List<Object>
+ GetAllQuestionsFromJSON(): void
+ GetRandomQuestion(): object
}
@enduml
```

