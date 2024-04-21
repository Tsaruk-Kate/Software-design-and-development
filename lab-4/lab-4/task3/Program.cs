using System;
using System.Collections.Generic;

// Observer interface
interface IEventListener
{
    void HandleEvent(string eventType);
}

// Subject interface
interface ISubject
{
    void Attach(IEventListener listener);
    void Detach(IEventListener listener);
    void Notify(string eventType);
}

// Concrete Observer class
class EventListener : IEventListener
{
    private string _eventType;

    public EventListener(string eventType)
    {
        _eventType = eventType;
    }

    public void HandleEvent(string eventType)
    {
        if (eventType == _eventType)
        {
            Console.WriteLine($"Event {_eventType} occurred!");
        }
    }
}

// LightHTML implementation
class LightNode
{
    public virtual string GetOuterHtml() { return ""; }
    public virtual string GetInnerHtml() { return ""; }
}

class LightTextNode : LightNode
{
    private string _text;
    public LightTextNode(string text)
    {
        _text = text;
    }
    public override string GetOuterHtml()
    {
        return _text;
    }
    public override string GetInnerHtml()
    {
        return _text;
    }
}

class LightElementNode : LightNode, ISubject
{
    private List<IEventListener> _listeners = new List<IEventListener>();
    private string _tagName;
    private string _displayType;
    private string _closingType;
    private List<LightNode> _children;
    private List<string> _cssClasses;

    public LightElementNode(string tagName, string displayType, string closingType, List<string> cssClasses)
    {
        _tagName = tagName;
        _displayType = displayType;
        _closingType = closingType;
        _cssClasses = cssClasses;
        _children = new List<LightNode>();
    }

    public void AddChild(LightNode node)
    {
        _children.Add(node);
    }

    public override string GetOuterHtml()
    {
        string result = $"<{_tagName} class=\"{string.Join(" ", _cssClasses)}\" display=\"{_displayType}\" closing=\"{_closingType}\">\n";
        foreach (var child in _children)
        {
            result += $"\t{child.GetOuterHtml()}\n";
        }
        if (_closingType == "closing")
        {
            result += $"</{_tagName}>";
        }
        return result;
    }

    public override string GetInnerHtml()
    {
        string result = "";
        foreach (var child in _children)
        {
            result += child.GetInnerHtml();
        }
        return result;
    }

    public void Attach(IEventListener listener)
    {
        _listeners.Add(listener);
    }

    public void Detach(IEventListener listener)
    {
        _listeners.Remove(listener);
    }

    public void Notify(string eventType)
    {
        foreach (var listener in _listeners)
        {
            listener.HandleEvent(eventType);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        LightElementNode header = new LightElementNode("h1", "block", "closing", new List<string>());
        LightTextNode headerText = new LightTextNode("Welcome to my page!");
        header.AddChild(headerText);

        // Subscribe event listeners to HTML elements
        EventListener clickListener = new EventListener("click");
        EventListener mouseoverListener = new EventListener("mouseover");

        header.Attach(clickListener);
        header.Attach(mouseoverListener);

        // Notify subscribers of events
        header.Notify("click");
        header.Notify("mouseover");

        // Output HTML code of elements
        Console.WriteLine(header.GetOuterHtml());
    }
}