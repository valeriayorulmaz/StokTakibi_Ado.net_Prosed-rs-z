
--�al��anlar--
select BarkodNo, sum(GirdiAdet) as 'Girdi ADED�' from Girdi  group by BarkodNo 
select BarkodNo, sum(��kt�Adet) as '��kt� ADED�' from ��kt�  group by BarkodNo
----�al��mayanlar**
select sum(GirdiAdet) as 'Girdi ADED�' ,sum(��kt�Adet) as '��kt� ADED�'  from Girdi g1 inner join ��kt� �1 on g1.BarkodNo=�1.BarkodNo group by BarkodNo order by BarkodNo


Select gir.BarkodNo,u.�r�nAd�, gir.Cins, SUM(gir.GirdiAdet) as 'Girdi Adedi', SUM(cik.��kt�Adet) as '��kt� Adedi'
From  Girdi gir, ��kt� cik, �r�n u
Where cik.BarkodNo = gir.BarkodNo and gir.BarkodNo = u.BarkodNo and gir.Cins = u.Cins
group by gir.BarkodNo, cik.BarkodNo, gir.Cins, u.�r�nAd�