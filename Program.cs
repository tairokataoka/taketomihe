List<string> lossPacketCreate(string input)
{
    FindmissingNumber(input);
    return new List<string>();
}

List<string> FindmissingNumber(string losspacket)//パケ落ち番号を探す
{
    int x = 0;
    string command = "53 00 CB 05 EB D0 00 00 00 02 CB";
    string newcommand;
    List<string> list = new List<string>();
    List<string> data = new List<string>();
    //dataに各行を格納する
    foreach (var item in losspacket.Split('\n'))
    {
        data.Add(item);
    }
    string segment = data[0].Substring(10, 13);
    for (int i = 0; i < data.Count; i++)
    {//パケットナンバーを取得
        string subdata0 = data[i].Substring(61, 4);
        string subdata1 = data[i].Substring(61, 2);
        string subdata2 = data[i].Substring(63, 2);
        string subdata3 = subdata1 + subdata2;

        //パケッナンバーを１０進数に変換
        int numbers = Convert.ToInt32(subdata3, 16);
        //変換した数字が連番になっていない番号を探す
        if (numbers == x)
        {
            x++;
        }
        else
        {//コマンドを作成
            newcommand = command.Substring(0, 9) + segment + subdata0 + command.Substring(31);
            list.Add(newcommand);
        }
    }
    return list;
}
