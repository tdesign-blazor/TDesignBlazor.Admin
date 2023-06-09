﻿namespace TDesign.Pro.Components;

/// <summary>
/// 可以打开带有表单的对话框功能的 <see cref="TButton"/> 。
/// </summary>
/// <typeparam name="TModel">表单模型的类型。</typeparam>
public class FormDialogButton<TModel> : FormDialogComponentBase<TModel> where TModel : class, new()
{
    /// <summary>
    /// 设置按钮的任意内容。
    /// </summary>
    [Parameter] public RenderFragment? ButtonContent { get; set; }
    /// <summary>
    /// 设置按钮显示的文本。若设置了 <see cref="ButtonContent"/>，则被忽略。
    /// </summary>
    [Parameter] public string? Text { get; set; }
    /// <summary>
    /// 按钮的主题。
    /// </summary>
    [Parameter] public Theme? Theme { get; set; } = Theme.Primary;
    /// <summary>
    /// 按钮的风格。
    /// </summary>
    [Parameter] public ButtonVarient Varient { get; set; } = ButtonVarient.Base;
    /// <summary>
    /// 按钮是否占满宽度。
    /// </summary>
    [Parameter] public bool Block { get; set; }
    /// <summary>
    /// 按钮的形状
    /// </summary>
    [Parameter] public ButtonShape Shape { get; set; } = ButtonShape.Rectangle;
    /// <summary>
    /// 按钮是否被禁用。
    /// </summary>
    [Parameter] public bool Disabled { get; set; }
    /// <summary>
    /// 按钮的尺寸。
    /// </summary>
    [Parameter] public Size ButtonSize { get; set; } = Size.Medium;
    protected override void OnInitialized()
    {
        base.OnInitialized();
        ButtonContent ??= builder => builder.AddContent(0, Text);
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.Component<TButton>()
            .Attribute(m=>m.Varient, Varient)
            .Attribute(m => m.Theme, Theme)
            .Attribute(m => m.Block, Block)
            .Attribute(m => m.Shape, Shape)
            .Attribute(m=>m.Disabled, Disabled)
            .Attribute(m=>m.Size, ButtonSize)
            .Attribute(m => m.AdditionalAttributes,AdditionalAttributes)
            .Attribute(m=>m.OnClick, HtmlHelper.Instance.Callback().Create<MouseEventArgs?>(this, OpenDialog))
            .Content(ButtonContent)
            .Close();
    }
}
