namespace interfaces
{
    public interface IMapper<TInput, TOutput>
    {
        public Task<TOutput> Map(TInput input);
    }
}