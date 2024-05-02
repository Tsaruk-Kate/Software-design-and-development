using System;
using System.Collections.Generic;

// Інтерфейс для стану
interface IHtmlState
{
    void RenderHtml(LightNode node);
    void SwitchToViewMode(LightNode node);
    void SwitchToEditMode(LightNode node);
}

// Конкретний стан "Режим перегляду"
class ViewMode : IHtmlState
{
    public void RenderHtml(LightNode node)
    {
        Console.WriteLine(node.GetOuterHtml());
    }

    public void SwitchToViewMode(LightNode node)
    {
        // Already in view mode
    }

    public void SwitchToEditMode(LightNode node)
    {
        node.SetEditMode();
    }
}

// Конкретний стан "Режим редагування"
class EditMode : IHtmlState
{
    public void RenderHtml(LightNode node)
    {
        Console.WriteLine(node.GetInnerHtml());
    }

    public void SwitchToViewMode(LightNode node)
    {
        node.SetViewMode();
    }

    public void SwitchToEditMode(LightNode node)
    {
        // Already in edit mode
    }
}

// Абстрактний клас LightNode
abstract class LightNode
{
    protected IHtmlState _state;

    public void SetState(IHtmlState state)
    {
        _state = state;
    }

    public abstract string GetOuterHtml();
    public abstract string GetInnerHtml();

    public virtual void SwitchToViewMode()
    {
        _state.SwitchToViewMode(this);
    }

    public virtual void SwitchToEditMode()
    {
        _state.SwitchToEditMode(this);
    }

    public virtual void SetEditMode() { }
    public virtual void SetViewMode() { }
}

// Клас текстового вузла
class LightTextNode : LightNode
{
    private string _text;

    public LightTextNode(string text)
    {
        _text = text;
        SetState(new ViewMode());
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

// Клас вузла елемента
class LightElementNode : LightNode
{
    private string _tagName;
    private string _displayType;
    private string _closingType;
    private List<LightNode> _children;
    private List<string> _cssClasses;
    private Dictionary<string, string> _attributes; // Додано словник для зберігання атрибутів

    public LightElementNode(string tagName, string displayType, string closingType, List<string> cssClasses)
    {
        _tagName = tagName;
        _displayType = displayType;
        _closingType = closingType;
        _cssClasses = cssClasses;
        _children = new List<LightNode>();
        _attributes = new Dictionary<string, string>(); // Ініціалізація словника атрибутів
        SetState(new ViewMode());
    }

    public void AddChild(LightNode node)
    {
        if (node != null)
            _children.Add(node);
    }

    // Методи для додавання та видалення атрибутів
    public void AddAttribute(string key, string value)
    {
        _attributes[key] = value;
    }

    public void RemoveAttribute(string key)
    {
        _attributes.Remove(key);
    }

    public void RemoveChild(LightNode node)
    {
        _children.Remove(node);
    }

    public override string GetOuterHtml()
    {
        string result = $"<{_tagName} class=\"{string.Join(" ", _cssClasses)}\" display=\"{_displayType}\" closing=\"{_closingType}\"";

        // Додавання атрибутів до виводу HTML
        foreach (var attribute in _attributes)
        {
            result += $" {attribute.Key}=\"{attribute.Value}\"";
        }

        result += ">\n";
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

    public override void SetEditMode()
    {
        SetState(new EditMode());
        foreach (var child in _children)
        {
            child.SetEditMode();
        }
    }

    public override void SetViewMode()
    {
        SetState(new ViewMode());
        foreach (var child in _children)
        {
            child.SetViewMode();
        }
    }
}

// Клас контексту
class HtmlContext
{
    private IHtmlState _state;

    public HtmlContext()
    {
        // Початковий стан - режим перегляду
        TransitionTo(new ViewMode());
    }

    // Змінюємо стан
    public void TransitionTo(IHtmlState state)
    {
        Console.WriteLine($"Context: Transition to {state.GetType().Name}.");
        _state = state;
    }

    // Метод відображення HTML
    public void RenderHtml(LightNode node)
    {
        _state.RenderHtml(node);
    }

    // Методи для додавання та видалення атрибутів в режимі редагування
    public void AddAttribute(LightElementNode node, string key, string value)
    {
        if (_state is EditMode)
        {
            node.AddAttribute(key, value);
        }
        else
        {
            Console.WriteLine("Attributes can only be added in edit mode.");
        }
    }

    public void RemoveAttribute(LightElementNode node, string key)
    {
        if (_state is EditMode)
        {
            node.RemoveAttribute(key);
        }
        else
        {
            Console.WriteLine("Attributes can only be removed in edit mode.");
        }
    }
}
// Інтерфейс команди
interface ICommand
{
    void Execute(); // Метод виконання команди
}

// Команда для додавання дочірнього вузла
class AddChildCommand : ICommand
{
    private LightElementNode _parent;
    private LightNode _child;

    public AddChildCommand(LightElementNode parent, LightNode child)
    {
        _parent = parent;
        _child = child;
    }

    public void Execute()
    {
        _parent.AddChild(_child); // Додає дочірній вузол до батьківського елементу
    }
}

// Команда для видалення дочірнього вузла
class RemoveChildCommand : ICommand
{
    private LightElementNode _parent;
    private LightNode _child;

    public RemoveChildCommand(LightElementNode parent, LightNode child)
    {
        _parent = parent;
        _child = child;
    }

    public void Execute()
    {
        _parent.RemoveChild(_child); // Видаляє дочірній вузол з батьківського елементу
    }
}

// Виконавець команд
class CommandInvoker
{
    private List<ICommand> _commands = new List<ICommand>();

    public void StoreAndExecute(ICommand command)
    {
        _commands.Add(command); // Зберігає команду та виконує її
        command.Execute();
    }
}

// Головний клас програми
class Program
{
    static void Main(string[] args)
    {
        HtmlContext context = new HtmlContext();
        CommandInvoker invoker = new CommandInvoker();

        LightElementNode header = new LightElementNode("h1", "block", "closing", new List<string>());
        LightTextNode headerText = new LightTextNode("Welcome to my page!");
        invoker.StoreAndExecute(new AddChildCommand(header, headerText));

        LightElementNode table = new LightElementNode("table", "block", "closing", new List<string> { "styled-table" });
        invoker.StoreAndExecute(new AddChildCommand(header, table));

        LightElementNode tableRow1 = new LightElementNode("tr", "block", "closing", new List<string>());
        invoker.StoreAndExecute(new AddChildCommand(table, tableRow1));

        LightElementNode tableData1 = new LightElementNode("td", "inline", "closing", new List<string>());
        LightTextNode dataText1 = new LightTextNode("Cell 1");
        invoker.StoreAndExecute(new AddChildCommand(tableRow1, tableData1));
        invoker.StoreAndExecute(new AddChildCommand(tableData1, dataText1));

        LightElementNode tableData2 = new LightElementNode("td", "inline", "closing", new List<string>());
        LightTextNode dataText2 = new LightTextNode("Cell 2");
        invoker.StoreAndExecute(new AddChildCommand(tableRow1, tableData2));
        invoker.StoreAndExecute(new AddChildCommand(tableData2, dataText2));

        // Remove the header
        invoker.StoreAndExecute(new RemoveChildCommand(header, headerText));

        // Render HTML
        context.RenderHtml(header);
        context.RenderHtml(table);

        // Transition to edit mode
        context.TransitionTo(new EditMode());

        // Edit HTML
        context.RenderHtml(header);
        context.RenderHtml(table);

        // Transition back to view mode
        context.TransitionTo(new ViewMode());

        // Render HTML again
        context.RenderHtml(header);
        context.RenderHtml(table);

        // Change mode among elements
        table.SetEditMode();

        // Add and remove attributes
        context.AddAttribute(table, "border", "1");
        context.AddAttribute(table, "cellpadding", "5");
        context.RemoveAttribute(table, "class");

        // Render HTML again
        context.RenderHtml(header);
        context.RenderHtml(table);
    }
}