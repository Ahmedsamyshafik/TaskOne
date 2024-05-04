namespace TaskOne.Service.Abstract
{
    public interface IMediaService
    {
        bool DeletePhysicalFile(string name);
        Task<string> Upload(IFormFile file);
    }
}
