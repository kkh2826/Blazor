namespace IdeaAppCore.Models
{
    public interface IIdeaRepository
    {
        Task<Idea> AddIdea(Idea idea);
        Task<List<Idea>> GetIdeas();
    }
}
