using System;
using System.Collections.Generic;

public class TextDocument
{
    private string content;

    public TextDocument(string initialContent)
    {
        content = initialContent;
    }

    public void Append(string text)
    {
        content += text;
    }

    public string GetContent()
    {
        return content;
    }

    public class TextDocumentMemento
    {
        private readonly string content;

        public TextDocumentMemento(string content)
        {
            this.content = content;
        }

        public string GetContent()
        {
            return content;
        }
    }

    public TextDocumentMemento CreateMemento()
    {
        return new TextDocumentMemento(content);
    }

    public void SetMemento(TextDocumentMemento memento)
    {
        content = memento.GetContent();
    }
}

public interface IMementoCareTaker
{
    void SaveMemento(TextDocument.TextDocumentMemento memento);
    TextDocument.TextDocumentMemento GetLastMemento();
}

public class TextEditor : IMementoCareTaker
{
    private TextDocument document;
    private Stack<TextDocument.TextDocumentMemento> history = new Stack<TextDocument.TextDocumentMemento>();

    public TextEditor(TextDocument document)
    {
        this.document = document;
    }

    public void AppendText(string text)
    {
        TextDocument.TextDocumentMemento memento = document.CreateMemento();
        document.Append(text);
        SaveMemento(memento);
    }

    public void Rollback()
    {
        TextDocument.TextDocumentMemento lastState = GetLastMemento();
        if (lastState != null)
        {
            document.SetMemento(lastState);
            Console.WriteLine("The document returned to its previous state.");
        }
        else
        {
            Console.WriteLine("There are no saved states to rollback.");
        }
    }

    public void ViewDocument()
    {
        if (document.GetContent() == "")
        {
            Console.WriteLine("The document is empty.");
        }
        else
        {
            Console.WriteLine(document.GetContent());
        }
    }

    public void SaveMemento(TextDocument.TextDocumentMemento memento)
    {
        history.Push(memento);
    }

    public TextDocument.TextDocumentMemento GetLastMemento()
    {
        if (history.Count > 0)
        {
            return history.Pop();
        }
        return null;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Text Editor!♥");
        TextDocument document = new TextDocument("");
        TextEditor editor = new TextEditor(document);

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1 - Add to document");
            Console.WriteLine("2 - Undo changes in the document");
            Console.WriteLine("3 - View document");
            Console.WriteLine("4 - Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter text to add:");
                    string text = Console.ReadLine();
                    editor.AppendText(text);
                    break;
                case "2":
                    editor.Rollback();
                    break;
                case "3":
                    editor.ViewDocument();
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Wrong choice. Try again.");
                    break;
            }
        }
    }
}