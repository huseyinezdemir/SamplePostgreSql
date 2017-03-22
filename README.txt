


C# ile entity framework code first kullanarak postgresql veritabanına bağlanır. Ef ve postgresql için aşağıdaki şekilde paketlerin yüklenmesi gerekir.

install-package Npgsql
install-package EntityFramework
install-package EntityFramework6.Npgsql

Paketler yüklendikten sonra config dosyasına DbProviderFactories bilgisinin eklenmesi gerekiyor. Eklenmez ise veritabanı bağlantısı sırasında exception fırlatıyor.

<system.data>
    <DbProviderFactories>
      <remove invariant="Npgsql" />
      <add name="Npgsql Data Provider" invariant="Npgsql" support="FF" description=".Net Framework Data Provider for Postgresql" type="Npgsql.NpgsqlFactory, Npgsql" />
    </DbProviderFactories>
</system.data>

Her çalıştırıldığında varsa silip yeniden veritabanı oluşturacaktır.

Fonksiyon v.s. tanımları için, OpulentDataContext altında tanımlanan CreateModel içerisinde veritabanına eklenebilir. 
