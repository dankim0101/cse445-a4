<?xml version="1.0" encoding="UTF-8"?>
<!-- 1) 루트가 잘못됨: Hotels → Hotel -->
<Hotel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
       xsi:noNamespaceSchemaLocation="Hotels.xsd">

  <!-- 2) 필수 속성 id 빠짐 -->
  <Hotel>
    <Name>Westin</Name>
    <!-- 4) Address 닫는 태그 누락 -->
    <Address NearestAirport="Sky Harbor">
      <Number>11</Number>
      <Street>E 7th St</Street>
      <City>Tempe</City>
      <State>AZ</State>
      <Zip>85281</Zip>
    <!-- </Address> 빠짐 -->
    <Phone>480-968-8885</Phone>
    <Phone>800-937-8461</Phone>
    <Rating>4.2</Rating>
  </Hotel>

  <Hotel id="2">
    <!-- 3) Phone 요소 누락 -->
    <Name>Desert Inn</Name>
    <Address>
      <Number>22</Number>
      <Street>S 3rd Ave</Street>
      <City>Phoenix</City>
      <State>AZ</State>
      <Zip>85004</Zip>
    </Address>
    <Rating>3.8</Rating>
  </Hotel>

  <Hotel id="3">
    <!-- 5) Name이 두 번 있음 -->
    <Name>Skyline Suites</Name>
    <Name>Duplicate Name</Name>
    <Address NearestAirport="Falcon Field">
      <Number>300</Number>
      <Street>Market St</Street>
      <City>Scottsdale</City>
      <State>AZ</State>
      <Zip>85251</Zip>
    </Address>
    <Phone>480-555-9876</Phone>
  </Hotel>

</Hotel>
