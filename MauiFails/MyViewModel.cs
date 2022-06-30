using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiFails;

public class MyViewModel
{
    MyService _service;
    public MyViewModel(MyService service)
    {
        _service = service;
    }

    public string GetMyValue()
    {
        return _service.GetNowString();
    }
}
