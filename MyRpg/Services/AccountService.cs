namespace MyRpg.Services;

public class AccountService
{
    private static IList<Account> database;

    static AccountService()
    {
        database = new List<Account>();
        database.Add(new Account() { Id = 0, Username = "admin", Password = "admin", Nickname = "系統管理員" });
        database.Add(new Account() { Id = 1, Username = "student1", Password = "student1", Nickname = "學生1" });
        database.Add(new Account() { Id = 2, Username = "student2", Password = "student2", Nickname = "學生2" });
        database.Add(new Account() { Id = 3, Username = "student3", Password = "student3", Nickname = "學生3" });
        database.Add(new Account() { Id = 4, Username = "student4", Password = "student4", Nickname = "學生4" });
        database.Add(new Account() { Id = 5, Username = "teacher1", Password = "teacher1", Nickname = "老師1" });
    }


    public bool Verify(string username, string password)
    {
        bool result = false;

        var fromDb = from db in database
            where db.Username == username && db.Password == password
            select db;

        if (fromDb.Any())
        {
            return true;
        }

        return result;
    }


    public Account GetByUserName(string username)
    {
        Account result = null;

        var fromDb = from db in database
            where db.Username == username
            select db;
        
        if (fromDb.Any())
        {
            result = fromDb.FirstOrDefault();
        }

        return result;
    }

    public Account Update(Account account)
    {
        Account result = null;

        var fromDb = from db in database
            where db.Id == account.Id
            select db;
        
        if (fromDb.Any())
        {
            result = fromDb.FirstOrDefault();
            //result.Username = account.Username; //理論上不可以修改
            result.Password = account.Password;
            result.Nickname = account.Nickname;
        }

        return result;
    }
    
    
    public bool Delete(int id)
    {
        bool result = false;

        var fromDb = from db in database
            where db.Id == id
            select db;
        
        if (fromDb.Any())
        {
            var temp = fromDb.FirstOrDefault();
            database.Remove(temp);
            result = true;

        }

        return result;
    }
}