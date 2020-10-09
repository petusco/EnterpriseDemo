namespace Enterprise.Domain.Contracts.UnitOfWorks
{
	public interface IUnitOfWork
	{
		void Commit();
	}
}
