namespace NDDTraining.Domain.ViewModels;

public class TrainingUsersDetails
{
    public int TrainingId { get; set;}
    public IList<int> RegistredUsers { get; set;}
    public int NRegistredUsers { get; set;}
    public IList<int> ProgressUsers { get; set;}
    public int NProgressUsers { get; set;}
    public IList<int> FinishedUsers { get; set;}
    public int NFinishedUsers { get; set;}

    public TrainingUsersDetails(int trainingId, IList<int> registredUsers, int nRegistredUsers, IList<int> progressUsers, int nProgressUsers, IList<int> finishedUsers, int nFinishedUsers)
    {
        TrainingId = trainingId;
        RegistredUsers = registredUsers;
        NRegistredUsers = nRegistredUsers;
        ProgressUsers = progressUsers;
        NProgressUsers = nProgressUsers;
        FinishedUsers = finishedUsers;
        NFinishedUsers = nFinishedUsers;
    }
}
