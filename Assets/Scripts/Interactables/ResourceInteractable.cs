namespace DEV205.Interactables
{
    public class ResourceInteractable : Interactable
    {
        protected override void Interact()
        {
            Destroy(gameObject);
        }
    }
}