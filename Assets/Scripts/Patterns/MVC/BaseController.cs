public abstract class BaseController<ViewType, ModelType> : IController<ViewType, ModelType> where ViewType : IView where ModelType : IModel
{
    public ModelType Model { get; set; }
    public ViewType View { get; set; }

    public BaseController(ModelType model, ViewType view)
    {
        this.Model = model;
        this.View = view;
    }
}