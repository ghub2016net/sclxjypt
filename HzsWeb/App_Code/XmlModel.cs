using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

#region 反序列化获取数据调用类+++
/// <summary>
/// Area Xml反序列化获取数据调用类
/// </summary>
public class ArrayOfHzsArea
{
    [XmlElement]
    public List<HzsModel.HZSModels.HzsArea> HzsArea { get; set; }


}

/// <summary>
/// tradesort.xml供求类型反序列化获取数据
/// </summary>
public class ArrayOfTradeSort
{
    [XmlElement]
    public List<HzsModel.HZSModels.TradeSort> TradeSort { get; set; }
}

/// <summary>
/// newstype.xml新闻类型反序列化获取数据
/// </summary>
public class ArrayOfNewsType
{
    [XmlElement]
    public List<HzsModel.HZSModels.NewsType> NewsType { get; set; }
}

/// <summary>
/// placestype.xml频道地区类型反序列化获取数据
/// </summary>
public class ArrayOfPlacesType
{
    [XmlElement]
    public List<HzsModel.HZSModels.PlacesType> PlacesType { get; set; }
}

/// <summary>
/// hzsusertype.xml合作社会员类型反序列化获取数据
/// </summary>
public class ArrayOfHzsUserType
{
    [XmlElement]
    public List<HzsModel.HZSModels.HzsUserType> HzsUserType { get; set; }
}

/// <summary>
/// hzsusersfsjb.xml合作社会员示范社级别类型反序列化获取数据
/// </summary>
public class ArrayOfHzsUserSfsjb
{
    [XmlElement]
    public List<HzsModel.HZSModels.HzsUserSfsjb> HzsUserSfsjb { get; set; }
}

/// <summary>
/// hzsusersfsjb.xml合作社会员示范社级别类型反序列化获取数据
/// </summary>
public class ArrayOfHzsUserJyms
{
    [XmlElement]
    public List<HzsModel.HZSModels.HzsUserJyms> HzsUserJyms { get; set; }
}
/// <summary>
/// 合作社类型
/// </summary>
public class ArrayOfHzsClass
{
    [XmlElement]
    public List<HzsModel.HZSModels.HzsClass> HzsClass { get; set; }
}
/// <summary>
/// 合作社单独页面（企业页面）新闻类型companytype.xml 
/// </summary>
public class ArrayOfCompanyType
{
    [XmlElement]
    public List<HzsModel.HZSModels.CompanyType> HzsClass { get; set; }
}
#endregion