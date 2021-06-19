// Copyright 2017-2021 Elringus (Artyom Sovetnikov). All Rights Reserved.

using UniRx.Async;

namespace Naninovel.Commands
{
    /// <summary>
    /// Permanently applies [text styles](/guide/text-printers.md#text-styles) to the contents of a text printer.
    /// </summary>
    /// <remarks>
    /// You can also use rich text tags inside text messages to apply the styles selectively.
    /// </remarks>
    [CommandAlias("style")]
    public class SetTextStyle : PrinterCommand
    {
        /// <summary>
        /// Text formatting tags to apply. Angle brackets should be omitted, eg use `b` for `&lt;b&gt;` and `size=100` for `&lt;size=100&gt;`. Use `default` keyword to reset the style.
        /// </summary>
        [ParameterAlias(NamelessParameterAlias), RequiredParameter]
        public StringListParameter TextStyles;
        /// <summary>
        /// ID of the printer actor to use. Will use a default one when not provided.
        /// </summary>
        [ParameterAlias("printer"), IDEActor(TextPrintersConfiguration.DefaultPathPrefix)]
        public StringParameter PrinterId;

        protected override string AssignedPrinterId => PrinterId;

        public override async UniTask ExecuteAsync (CancellationToken cancellationToken = default)
        {
            var printer = await GetOrAddPrinterAsync();
            if (cancellationToken.CancelASAP) return;

            if (TextStyles.Length == 1 && TextStyles[0].Value.EqualsFastIgnoreCase("default"))
                printer.RichTextTags = null;
            else printer.RichTextTags = TextStyles;
        }
    } 
}
