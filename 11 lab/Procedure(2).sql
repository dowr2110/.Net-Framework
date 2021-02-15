create proc tb
	@Nomer int ,
	@Tip_vklada nvarchar(50) ,
	@Balans int, 
	@Data_otryt date
as
insert into Scet(Nomer ,	Tip_vklada ,	Balans , 	Data_otryt  )
values (@Nomer ,@Tip_vklada,@Balans,@Data_otryt)

create proc tb1
	@Nomer int ,
	@Family_name nvarchar(50),
	@Name_name nvarchar(50),
	@Pasport_no nvarchar(50),
	@Mesto_rojdeniya nvarchar(50),
	@Data_rojd date
as
insert into InfoUser( Nomer  ,	Family_name  ,	Name_name  ,	Pasport_no  ,	Mesto_rojdeniya ,	Data_rojd  )
values (@Nomer, @Family_name, @Name_name,@Pasport_no,@Mesto_rojdeniya,@Data_rojd)


