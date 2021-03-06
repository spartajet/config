﻿using Config.Net.Stores;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Config.Net.Tests.Stores
{
   public class YamlFileConfigStoreTest : AbstractTestFixture
   {
      private YamlFileConfigStore _yaml;

      public YamlFileConfigStoreTest()
      {
         var testFile = @"..\..\..\..\..\appveyor.yml";
         _yaml = new YamlFileConfigStore(testFile);
      }

      [Fact]
      public void Can_read_simple_property()
      {
         string image = _yaml.Read("image");

         Assert.Equal("Visual Studio 2017", image);
      }

      [Fact]
      public void Can_read_nested_node()
      {
         string project = _yaml.Read("build.project");

         Assert.Equal("src/Config.Net.sln", project);
      }

      [Fact]
      public void Can_read_multiline()
      {
         string cmd = _yaml.Read("test_script.cmd");

         Assert.Equal(@"cd src\Config.Net.Tests
dotnet test
cd ..\..", cmd, false, true, true);

      }
   }
}