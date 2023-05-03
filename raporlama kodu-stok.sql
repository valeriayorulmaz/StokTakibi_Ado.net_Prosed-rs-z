
--çalýþanlar--
select BarkodNo, sum(GirdiAdet) as 'Girdi ADEDÝ' from Girdi  group by BarkodNo 
select BarkodNo, sum(ÇýktýAdet) as 'Çýktý ADEDÝ' from Çýktý  group by BarkodNo
----çalýþmayanlar**
select sum(GirdiAdet) as 'Girdi ADEDÝ' ,sum(ÇýktýAdet) as 'Çýktý ADEDÝ'  from Girdi g1 inner join Çýktý ç1 on g1.BarkodNo=ç1.BarkodNo group by BarkodNo order by BarkodNo


Select gir.BarkodNo,u.ÜrünAdý, gir.Cins, SUM(gir.GirdiAdet) as 'Girdi Adedi', SUM(cik.ÇýktýAdet) as 'Çýktý Adedi'
From  Girdi gir, Çýktý cik, Ürün u
Where cik.BarkodNo = gir.BarkodNo and gir.BarkodNo = u.BarkodNo and gir.Cins = u.Cins
group by gir.BarkodNo, cik.BarkodNo, gir.Cins, u.ÜrünAdý