using System.Globalization;
using TableEditor.Core.Tables.ValueTypes.Expressions.Analysis.Symbols;

namespace TableEditor.Core.Tables.ValueTypes.Expressions.Analysis;

internal class Lexer
{
    private string _text;
    private int _position;
    private CultureInfo _cultureInfo;

    public Lexer(string text)
    {
        _text = text;
        _cultureInfo = CultureInfo.CurrentCulture;
    }

    public char GetCurrent()
    {
        return Peek(0);
    }

    private char Peek(int offset)
    {
        if (_position + offset >= _text.Length)
            return '\0';

        return _text[_position + offset];
    }

    private void Next(int delta = 1)
    {
        _position += delta;
    }

    private void NextDoWhile(Predicate<char> predicate)
    {
        NextDoWhile((c, _) => predicate(c));
    }

    private void NextDoWhile(Func<char, int, bool> predicate)
    {
        int i = 0;

        do 
        {
            Next();
            i++;
        }
        while (predicate(GetCurrent(), i));
    }

    public IEnumerable<Symbol> Lex()
    {
        while (_position < _text.Length)
            yield return LexOne();
    }

    private Symbol LexOne()
    {
        char current = GetCurrent();

        if (char.IsWhiteSpace(current))
            return LexWhiteSpace();

        if (char.IsLetter(current))
            return LexLetter();

        if (char.IsDigit(current))
            return LexNumber();

        var separator = _cultureInfo.NumberFormat.NumberDecimalSeparator;

        if (separator.StartsWith(current))
            return LexNumberDecimalSeparator();

        var textSpan = new TextSpan($"{current}", _position);

        switch (current)
        {
            case '+':
                Next();
                return new Symbol(SymbolType.Plus, textSpan);

            case '-':
                Next();
                return new Symbol(SymbolType.Minus, textSpan);

            case '/':
                Next();
                return new Symbol(SymbolType.Slash, textSpan);

            case '*':
                Next();
                return new Symbol(SymbolType.Star, textSpan);

            case '^':
                Next();
                return new Symbol(SymbolType.Circumflex, textSpan);

            case ':':
                Next();
                return new Symbol(SymbolType.DoubleDot, textSpan);

            case '|':
                Next(2);
                return new Symbol(SymbolType.Pipe, textSpan);

            case '&':
                Next(2);
                return new Symbol(SymbolType.Ampersand, textSpan);
        }

        throw new InvalidOperationException($"Unknown symbol; Position: {_position}; Text: {GetCurrent()}");
    }

    private Symbol LexWhiteSpace()
    {
        int startPosition = _position;

        NextDoWhile(c => char.IsWhiteSpace(c));

        var textSpan = new TextSpan(baseText: _text, startPosition, length: _position - startPosition);

        return new Symbol(SymbolType.WhiteSpace, textSpan);
    }

    private Symbol LexLetter()
    {
        var startPosition = _position;

        NextDoWhile(c => char.IsLetter(c));

        var textSpan = new TextSpan(baseText: _text, startPosition, length: _position - startPosition);

        return new Symbol(SymbolType.Letter, textSpan);
    }

    private Symbol LexNumber()
    {
        var startPosition = _position;

        NextDoWhile(c => char.IsDigit(c));

        var textSpan = new TextSpan(baseText: _text, startPosition, length: _position - startPosition);

        return new Symbol(SymbolType.Number, textSpan);
    }

    private Symbol LexNumberDecimalSeparator()
    {
        var separator = _cultureInfo.NumberFormat.NumberDecimalSeparator;

        var startPosition = _position;

        NextDoWhile((c, i) => i < separator.Length ? separator[i] == c : false);

        var textSpan = new TextSpan(separator, startPosition);

        return new Symbol(SymbolType.NumberDecimalSeparator, textSpan);
    }
}