--新闻类型表检测有子类的ispublic=1
declare @n int 
declare @c int 
declare @u int
set @u=0 
set @c=1
set @n= (select count(1) from NewsType) 
while @c<@n
	begin
		if((select count(1) from NewsType where pid = ( select ntypeid from  NewsType where id=@c))>0)
			begin
				update NewsType set ispublic=1 where id=@c
			end
		set @c=@c+1
	end
