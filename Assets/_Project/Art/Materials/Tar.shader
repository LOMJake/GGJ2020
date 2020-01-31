// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Tar"
{
	Properties
	{
		_Texture0("Texture 0", 2D) = "white" {}
		_Color0("Color 0", Color) = (1,1,1,1)
		_Exponent("Exponent", Range( 3 , 32)) = 31.9889
		_Scale("Scale", Range( 0 , 10)) = 1
		_DistExp("DistExp", Range( -10 , 10)) = 0
		_TimeScale("TimeScale", Range( 0 , 10)) = 0
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Pass
		{
			ColorMask 0
			ZWrite On
		}

		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Off
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Lambert keepalpha addshadow fullforwardshadows vertex:vertexDataFunc 
		struct Input
		{
			half filler;
		};

		uniform sampler2D _Texture0;
		uniform float4 _Texture0_ST;
		uniform float _DistExp;
		uniform float _TimeScale;
		uniform float _Exponent;
		uniform float _Scale;
		uniform float4 _Color0;

		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float2 uv0_Texture0 = v.texcoord.xy * _Texture0_ST.xy + _Texture0_ST.zw;
			float mulTime18 = _Time.y * _TimeScale;
			float2 appendResult19 = (float2(0.0 , mulTime18));
			float4 tex2DNode5 = tex2Dlod( _Texture0, float4( ( uv0_Texture0 + appendResult19 ), 0, 0.0) );
			float3 ase_vertexNormal = v.normal.xyz;
			v.vertex.xyz += ( ( pow( ( pow( uv0_Texture0.y , _DistExp ) * tex2DNode5.r ) , _Exponent ) * _Scale ) * ase_vertexNormal );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			float4 temp_output_28_0 = _Color0;
			o.Albedo = temp_output_28_0.rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=17600
-1415;788;1306;799;3119.013;797.8958;2.877878;True;False
Node;AmplifyShaderEditor.RangedFloatNode;25;-2190.238,531.2961;Float;False;Property;_TimeScale;TimeScale;5;0;Create;True;0;0;False;0;0;0.1;0;10;0;1;FLOAT;0
Node;AmplifyShaderEditor.TexturePropertyNode;2;-2072.486,-56.70191;Float;True;Property;_Texture0;Texture 0;0;0;Create;True;0;0;False;0;None;None;False;white;Auto;Texture2D;-1;0;1;SAMPLER2D;0
Node;AmplifyShaderEditor.SimpleTimeNode;18;-1726.594,495.6394;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;3;-1782.787,23.13595;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DynamicAppendNode;19;-1470.944,479.88;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;27;-1374.231,120.5101;Float;False;Property;_DistExp;DistExp;4;0;Create;True;0;0;False;0;0;-0.02;-10;10;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;20;-1343.121,341.5492;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.PowerNode;24;-1035.354,-36.00023;Inherit;True;False;2;0;FLOAT;0;False;1;FLOAT;7.04;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;5;-1199.947,267.8747;Inherit;True;Property;_TextureSample1;Texture Sample 1;1;0;Create;True;0;0;False;0;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;12;-1280.472,564.5132;Float;False;Property;_Exponent;Exponent;2;0;Create;True;0;0;False;0;31.9889;6.1;3;32;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;16;-806.6044,281.2387;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;10;-433.3934,820.953;Float;False;Property;_Scale;Scale;3;0;Create;True;0;0;False;0;1;1.69;0;10;0;1;FLOAT;0
Node;AmplifyShaderEditor.PowerNode;7;-644.6342,391.5346;Inherit;True;False;2;0;FLOAT;0;False;1;FLOAT;10;False;1;FLOAT;0
Node;AmplifyShaderEditor.NormalVertexDataNode;37;-39.1724,853.6314;Inherit;False;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;39;-132.1257,619.8523;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;1;-1188.547,-316.5701;Inherit;True;Property;_TextureSample0;Texture Sample 0;0;0;Create;True;0;0;False;0;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;17;-1630.287,257.5;Float;False;Constant;_Vector0;Vector 0;3;0;Create;True;0;0;False;0;0,0;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;29;-369.557,-148.7373;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;28;-726.7658,-381.6236;Float;False;Property;_Color0;Color 0;1;0;Create;True;0;0;False;0;1,1,1,1;1,1,1,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;38;378.9441,629.5752;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;35;867.45,-29.14327;Float;False;True;-1;2;ASEMaterialInspector;0;0;Lambert;Tar;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;True;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;18;0;25;0
WireConnection;3;2;2;0
WireConnection;19;1;18;0
WireConnection;20;0;3;0
WireConnection;20;1;19;0
WireConnection;24;0;3;2
WireConnection;24;1;27;0
WireConnection;5;0;2;0
WireConnection;5;1;20;0
WireConnection;16;0;24;0
WireConnection;16;1;5;1
WireConnection;7;0;16;0
WireConnection;7;1;12;0
WireConnection;39;0;7;0
WireConnection;39;1;10;0
WireConnection;1;0;2;0
WireConnection;1;1;3;0
WireConnection;29;0;28;0
WireConnection;29;1;5;1
WireConnection;38;0;39;0
WireConnection;38;1;37;0
WireConnection;35;0;28;0
WireConnection;35;11;38;0
ASEEND*/
//CHKSM=3274755D7795B369E04B3C1F6D5F8C4AC4AE8F82