﻿var arrtrade = new Array();
function tsort(pid,tid,tname) {this.pid = pid;this.tid = tid;this.tname = tname;}arrtrade = new Array(276);
arrtrade[0]=new tsort('0','1','粮油食品');arrtrade[1]=new tsort('9','2','稻谷');arrtrade[2]=new tsort('9','3','麦类');arrtrade[3]=new tsort('9','4','玉米');arrtrade[4]=new tsort('9','5','豆类');arrtrade[5]=new tsort('9','6','高粱、粟、黍');arrtrade[6]=new tsort('9','7','薯类');arrtrade[7]=new tsort('9','8','其他粮食');arrtrade[8]=new tsort('1','9','粮食');arrtrade[9]=new tsort('1','10','米面类');arrtrade[10]=new tsort('1','11','含油子仁、果仁、籽');arrtrade[11]=new tsort('1','12','食用油');arrtrade[12]=new tsort('10','13','面粉');arrtrade[13]=new tsort('10','14','大米');arrtrade[14]=new tsort('10','15','米粉');arrtrade[15]=new tsort('10','16','粉丝、粉皮');arrtrade[16]=new tsort('10','17','面条');arrtrade[17]=new tsort('10','18','其他米面类');arrtrade[18]=new tsort('11','19','花生');arrtrade[19]=new tsort('11','20','芝麻');arrtrade[20]=new tsort('11','21','松子');arrtrade[21]=new tsort('11','22','油菜籽');arrtrade[22]=new tsort('11','23','杏仁');arrtrade[23]=new tsort('11','24','其他含油子仁、果仁、籽');arrtrade[24]=new tsort('12','25','花生油');arrtrade[25]=new tsort('12','26','豆油');arrtrade[26]=new tsort('12','27','菜籽油');arrtrade[27]=new tsort('12','28','核桃油');arrtrade[28]=new tsort('12','29','芝麻油');arrtrade[29]=new tsort('12','30','棕榈油');arrtrade[30]=new tsort('12','31','葡萄籽油');arrtrade[31]=new tsort('12','32','山茶油');arrtrade[32]=new tsort('12','33','橄榄油');arrtrade[33]=new tsort('12','34','调和油');arrtrade[34]=new tsort('12','35','动物油');arrtrade[35]=new tsort('12','36','其他食用油');arrtrade[36]=new tsort('0','37','蔬、果、茶、饮');arrtrade[37]=new tsort('37','38','新鲜蔬菜');arrtrade[38]=new tsort('37','39','辛辣蔬菜');arrtrade[39]=new tsort('37','40','食用菌');arrtrade[40]=new tsort('37','41','生鲜水果');arrtrade[41]=new tsort('37','42','坚果、干果');arrtrade[42]=new tsort('37','43','蔬菜制品');arrtrade[43]=new tsort('37','44','茶叶');arrtrade[44]=new tsort('37','45','咖啡豆、可可');arrtrade[45]=new tsort('38','46','竹笋类');arrtrade[46]=new tsort('38','47','花菜类');arrtrade[47]=new tsort('38','48','叶菜类');arrtrade[48]=new tsort('38','49','豆荚类');arrtrade[49]=new tsort('38','50','瓜果类');arrtrade[50]=new tsort('38','51','块茎类');arrtrade[51]=new tsort('38','52','根菜类');arrtrade[52]=new tsort('38','53','水生菜类');arrtrade[53]=new tsort('38','54','野生菜类');arrtrade[54]=new tsort('38','55','其他新鲜蔬菜');arrtrade[55]=new tsort('39','56','姜');arrtrade[56]=new tsort('39','57','蒜');arrtrade[57]=new tsort('39','58','葱');arrtrade[58]=new tsort('39','59','辣椒');arrtrade[59]=new tsort('39','60','其他辛辣蔬菜');arrtrade[60]=new tsort('40','61','香菇');arrtrade[61]=new tsort('40','62','金针菇');arrtrade[62]=new tsort('40','63','猴头菇');arrtrade[63]=new tsort('40','64','平菇');arrtrade[64]=new tsort('40','65','竹荪');arrtrade[65]=new tsort('40','66','灰树花');arrtrade[66]=new tsort('40','67','鸡腿菇');arrtrade[67]=new tsort('40','68','草菇');arrtrade[68]=new tsort('40','69','姬松茸');arrtrade[69]=new tsort('40','70','白灵菇');arrtrade[70]=new tsort('40','71','蘑菇');arrtrade[71]=new tsort('40','72','木耳');arrtrade[72]=new tsort('40','73','其他食用菌');arrtrade[73]=new tsort('41','74','草莓');arrtrade[74]=new tsort('41','75','桃');arrtrade[75]=new tsort('41','76','荔枝');arrtrade[76]=new tsort('41','77','苹果');arrtrade[77]=new tsort('41','78','柑桔、橙、柚');arrtrade[78]=new tsort('41','79','梨');arrtrade[79]=new tsort('41','80','葡萄');arrtrade[80]=new tsort('41','81','香蕉');arrtrade[81]=new tsort('41','82','菠萝');arrtrade[82]=new tsort('41','83','枣');arrtrade[83]=new tsort('41','84','桂圆');arrtrade[84]=new tsort('41','85','瓜类');arrtrade[85]=new tsort('41','86','枇杷');arrtrade[86]=new tsort('41','87','其他生鲜水果');arrtrade[87]=new tsort('42','88','生核桃');arrtrade[88]=new tsort('42','89','生白果');arrtrade[89]=new tsort('42','90',' 生板栗');arrtrade[90]=new tsort('42','91','生开心果');arrtrade[91]=new tsort('42','92','生瓜子');arrtrade[92]=new tsort('42','93','生榛子');arrtrade[93]=new tsort('42','94','其他坚果、干果');arrtrade[94]=new tsort('43','95','脱水蔬菜');arrtrade[95]=new tsort('43','97','酱腌菜');arrtrade[96]=new tsort('43','98','其他蔬菜制品');arrtrade[97]=new tsort('44','100','绿茶');arrtrade[98]=new tsort('44','101','红茶');arrtrade[99]=new tsort('44','103','青茶');arrtrade[100]=new tsort('44','104','黑茶');arrtrade[101]=new tsort('44','105','白茶');arrtrade[102]=new tsort('44','106','黄茶');arrtrade[103]=new tsort('44','107','其他茶叶');arrtrade[104]=new tsort('0','108','畜、禽、皮、毛');arrtrade[105]=new tsort('108','109','牲畜');arrtrade[106]=new tsort('108','110','禽类');arrtrade[107]=new tsort('108','111','特种养殖动物');arrtrade[108]=new tsort('108','114','羽毛、羽绒');arrtrade[109]=new tsort('109','117','羊');arrtrade[110]=new tsort('109','118','马');arrtrade[111]=new tsort('109','119','其他牲畜');arrtrade[112]=new tsort('110','120','鸡');arrtrade[113]=new tsort('110','121','鸭');arrtrade[114]=new tsort('110','122','鹅');arrtrade[115]=new tsort('110','124','其他禽类 ');arrtrade[116]=new tsort('112','125','牛皮');arrtrade[117]=new tsort('112','126','羊皮');arrtrade[118]=new tsort('112','127','猪皮');arrtrade[119]=new tsort('112','128','兔皮');arrtrade[120]=new tsort('112','129','狐狸皮');arrtrade[121]=new tsort('0','131','水产品');arrtrade[122]=new tsort('131','132','鲜活水产品');arrtrade[123]=new tsort('131','133','粗加工水产品');arrtrade[124]=new tsort('132','134','鱼类');arrtrade[125]=new tsort('132','135','虾类');arrtrade[126]=new tsort('132','137','藻类');arrtrade[127]=new tsort('132','138','蟹类');arrtrade[128]=new tsort('132','139','鳖类');arrtrade[129]=new tsort('132','140','其他鲜活水产品');arrtrade[130]=new tsort('133','141','冷冻粗加工水产品');arrtrade[131]=new tsort('133','142','干制水产品');arrtrade[132]=new tsort('133','143','腌制水产品');arrtrade[133]=new tsort('133','144','其他粗加工水产品');arrtrade[134]=new tsort('145','146','肉类');arrtrade[135]=new tsort('146','150','猪肉');arrtrade[136]=new tsort('146','151','狗肉');arrtrade[137]=new tsort('146','152','驴肉');arrtrade[138]=new tsort('146','156','鸡肉');arrtrade[139]=new tsort('146','158','鹅肉');arrtrade[140]=new tsort('146','159','兔肉');arrtrade[141]=new tsort('146','160','其他肉类');arrtrade[142]=new tsort('0','161','其他农产品');arrtrade[143]=new tsort('161','162','烟草');arrtrade[144]=new tsort('161','163','棉类');arrtrade[145]=new tsort('161','164','麻类');arrtrade[146]=new tsort('161','165','蚕茧、蚕丝');arrtrade[147]=new tsort('0','166','园艺');arrtrade[148]=new tsort('166','167','绿化苗木');arrtrade[149]=new tsort('166','168','花卉');arrtrade[150]=new tsort('166','169','花卉种子、种苗');arrtrade[151]=new tsort('166','170','园艺用具');arrtrade[152]=new tsort('166','171','庭院灯');arrtrade[153]=new tsort('166','172','园林石工艺品');arrtrade[154]=new tsort('166','173','雕塑');arrtrade[155]=new tsort('166','174','亭子');arrtrade[156]=new tsort('166','175','喷泉');arrtrade[157]=new tsort('166','176','长椅');arrtrade[158]=new tsort('167','177','树木盆景');arrtrade[159]=new tsort('167','178','乔木');arrtrade[160]=new tsort('167','179','灌木');arrtrade[161]=new tsort('167','180','竹类植物');arrtrade[162]=new tsort('167','181','球类植物');arrtrade[163]=new tsort('167','183','棕榈类植物');arrtrade[164]=new tsort('167','185','果树');arrtrade[165]=new tsort('167','186','其他绿化苗木');arrtrade[166]=new tsort('168','187','鲜花');arrtrade[167]=new tsort('168','188','花草盆景');arrtrade[168]=new tsort('168','189','一二年生草花');arrtrade[169]=new tsort('168','190','室内观叶植物');arrtrade[170]=new tsort('168','192','室内观果植物');arrtrade[171]=new tsort('168','193','其他花卉');arrtrade[172]=new tsort('170','194','灌溉工具');arrtrade[173]=new tsort('170','195','园艺剪');arrtrade[174]=new tsort('170','196',' 花盆容器');arrtrade[175]=new tsort('170','197','栽培基质');arrtrade[176]=new tsort('170','198',' 花架');arrtrade[177]=new tsort('170','200','其他园艺用具');arrtrade[178]=new tsort('0','201','农用物资');arrtrade[179]=new tsort('201','202','种子、种苗');arrtrade[180]=new tsort('201','203','饲料');arrtrade[181]=new tsort('201','204','饲料添加剂');arrtrade[182]=new tsort('201','205','农药原药');arrtrade[183]=new tsort('201','206','农药制剂');arrtrade[184]=new tsort('201','209','植物生长调节剂');arrtrade[185]=new tsort('201','210','畜用药');arrtrade[186]=new tsort('201','212','渔业用具');arrtrade[187]=new tsort('201','213','农业用橡胶制品');arrtrade[188]=new tsort('201','214','工农业用塑料制品');arrtrade[189]=new tsort('201','215','植物提取物');arrtrade[190]=new tsort('201','218','动物原药材');arrtrade[191]=new tsort('201','219','工业用动植物油');arrtrade[192]=new tsort('201','220','原木');arrtrade[193]=new tsort('201','221','竹木、藤苇、干草');arrtrade[194]=new tsort('201','223','其他农用物资');arrtrade[195]=new tsort('202','224','动物种苗');arrtrade[196]=new tsort('202','225','农作物种子');arrtrade[197]=new tsort('202','226','食用菌菌种');arrtrade[198]=new tsort('203','230','其他饲料');arrtrade[199]=new tsort('43','96','冷冻蔬菜');arrtrade[200]=new tsort('44','99','保健茶');arrtrade[201]=new tsort('44','102','花茶');arrtrade[202]=new tsort('108','112','生皮、毛皮');arrtrade[203]=new tsort('108','113','动物毛鬃');arrtrade[204]=new tsort('109','115','猪');arrtrade[205]=new tsort('109','116','牛');arrtrade[206]=new tsort('110','123','肉鸽');arrtrade[207]=new tsort('112','130','其他生皮、毛皮');arrtrade[208]=new tsort('132','136','贝类');arrtrade[209]=new tsort('0','145','肉、蛋、奶');arrtrade[210]=new tsort('145','147','肠衣');arrtrade[211]=new tsort('145','148','禽蛋');arrtrade[212]=new tsort('145','149','蛋制品');arrtrade[213]=new tsort('146','153','鹿肉');arrtrade[214]=new tsort('146','154','牛肉');arrtrade[215]=new tsort('146','155','羊肉');arrtrade[216]=new tsort('146','157','鸭肉');arrtrade[217]=new tsort('167','182','攀援植物');arrtrade[218]=new tsort('167','184','草坪');arrtrade[219]=new tsort('168','191','室内观花植物');arrtrade[220]=new tsort('170','199','园艺护栏');arrtrade[221]=new tsort('201','207','化肥');arrtrade[222]=new tsort('201','208','生物肥料');arrtrade[223]=new tsort('201','211','农业用具');arrtrade[224]=new tsort('201','216','动物提取物');arrtrade[225]=new tsort('201','217','植物原药材');arrtrade[226]=new tsort('201','222','木炭');arrtrade[227]=new tsort('202','227','其他种子、种苗');arrtrade[228]=new tsort('203','228','植物性饲料');arrtrade[229]=new tsort('203','229','动物性饲料');arrtrade[230]=new tsort('204','231','营养性添加剂');arrtrade[231]=new tsort('204','232','药物性添加剂');arrtrade[232]=new tsort('204','233','饲料保藏剂');arrtrade[233]=new tsort('204','234','其他饲料添加剂');arrtrade[234]=new tsort('205','235','除草剂');arrtrade[235]=new tsort('205','236','杀菌剂');arrtrade[236]=new tsort('205','237','杀虫剂');arrtrade[237]=new tsort('205','238','杀螨剂');arrtrade[238]=new tsort('205','239','杀鼠剂');arrtrade[239]=new tsort('205','240','其他农药原药');arrtrade[240]=new tsort('206','241','除草剂混剂');arrtrade[241]=new tsort('206','242','杀菌剂混剂');arrtrade[242]=new tsort('206','243','杀虫、杀螨混剂');arrtrade[243]=new tsort('206','244','其他农药制剂');arrtrade[244]=new tsort('207','245','磷肥');arrtrade[245]=new tsort('207','246','钾肥');arrtrade[246]=new tsort('207','247','氮肥');arrtrade[247]=new tsort('207','248','复合肥料');arrtrade[248]=new tsort('207','249','其他化肥');arrtrade[249]=new tsort('211','250','农用工具');arrtrade[250]=new tsort('211','251','塑料薄膜');arrtrade[251]=new tsort('211','252','温室、大棚');arrtrade[252]=new tsort('211','253','防虫网');arrtrade[253]=new tsort('211','254','其他农业用具');arrtrade[254]=new tsort('0','256','农业机械');arrtrade[255]=new tsort('256','257','食用油加工设备');arrtrade[256]=new tsort('256','258','屠宰及肉类初加工设备');arrtrade[257]=new tsort('256','259','饲料加工设备');arrtrade[258]=new tsort('256','260','粮食加工设备');arrtrade[259]=new tsort('256','261','土壤耕整机械');arrtrade[260]=new tsort('256','262','种植机械');arrtrade[261]=new tsort('256','263','植保机械');arrtrade[262]=new tsort('256','264','排灌机械');arrtrade[263]=new tsort('256','265','收获机械');arrtrade[264]=new tsort('256','266','场上作业机械');arrtrade[265]=new tsort('256','267','拖拉机');arrtrade[266]=new tsort('256','268','施肥机械');arrtrade[267]=new tsort('256','269','农业实验设备');arrtrade[268]=new tsort('256','270','农机配件');arrtrade[269]=new tsort('256','271','其他农业机械');arrtrade[270]=new tsort('256','272','肥料加工设备');arrtrade[271]=new tsort('256','273','畜牧、养殖业机械');arrtrade[272]=new tsort('256','274','渔业机械');arrtrade[273]=new tsort('256','275','林业机械');arrtrade[274]=new tsort('256','277','其他');arrtrade[275]=new tsort('0','278','菌类');