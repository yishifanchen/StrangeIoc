using UnityEngine;
using System.Collections;
using ProtoBuf;
using System.IO;

public class TestProtobuf : MonoBehaviour {
    
	void Start () {
        //User user = new User();
        //user.ID = 100;
        //user.Username = "fsf";
        //user.Password = "2324";
        //user.Level = 3443;
        //user._UserType = User.UserType.Master;

        //FileStream fs = File.Create(Application.dataPath + "/user.bin");
        //Serializer.Serialize<User>(fs, user);
        //fs.Close();

        User user = null;

        using (var fs = File.OpenRead(Application.dataPath + "/user.bin"))
        {
            user = Serializer.Deserialize<User>(fs);
        }
        print(user.ID);
        print(user._UserType);
        print(user.Username);
        print(user.Password);
        print(user.Level);

    }
	
	void Update () {
	
	}
}
