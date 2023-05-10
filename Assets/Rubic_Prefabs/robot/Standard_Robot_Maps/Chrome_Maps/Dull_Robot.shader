// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Chrome Robot Dull"
{
	Properties
	{
		_ROBOT2Albedo("ROBOT2 [Albedo]", 2D) = "white" {}
		_ROBOT2Gloss("ROBOT2 [Gloss]", 2D) = "white" {}
		_TextureSample0("Texture Sample 0", 2D) = "white" {}
		_ROBOT2Normal("ROBOT2 [Normal]", 2D) = "bump" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf StandardSpecular keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _ROBOT2Normal;
		uniform float4 _ROBOT2Normal_ST;
		uniform sampler2D _ROBOT2Albedo;
		uniform float4 _ROBOT2Albedo_ST;
		uniform sampler2D _TextureSample0;
		uniform float4 _TextureSample0_ST;
		uniform sampler2D _ROBOT2Gloss;
		uniform float4 _ROBOT2Gloss_ST;

		void surf( Input i , inout SurfaceOutputStandardSpecular o )
		{
			float2 uv_ROBOT2Normal = i.uv_texcoord * _ROBOT2Normal_ST.xy + _ROBOT2Normal_ST.zw;
			float3 tex2DNode10 = UnpackNormal( tex2D( _ROBOT2Normal, uv_ROBOT2Normal ) );
			o.Normal = tex2DNode10;
			float2 uv_ROBOT2Albedo = i.uv_texcoord * _ROBOT2Albedo_ST.xy + _ROBOT2Albedo_ST.zw;
			o.Albedo = tex2D( _ROBOT2Albedo, uv_ROBOT2Albedo ).rgb;
			float2 uv_TextureSample0 = i.uv_texcoord * _TextureSample0_ST.xy + _TextureSample0_ST.zw;
			float4 tex2DNode5 = tex2D( _TextureSample0, uv_TextureSample0 );
			o.Specular = tex2DNode5.rgb;
			float2 uv_ROBOT2Gloss = i.uv_texcoord * _ROBOT2Gloss_ST.xy + _ROBOT2Gloss_ST.zw;
			float4 tex2DNode2 = tex2D( _ROBOT2Gloss, uv_ROBOT2Gloss );
			float4 temp_cast_2 = (0.4).xxxx;
			float4 clampResult8 = clamp( tex2DNode2 , float4( 0,0,0,0 ) , temp_cast_2 );
			o.Smoothness = clampResult8.r;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=16900
-1878;71;1586;742;1718.157;537.5273;1.747277;True;True
Node;AmplifyShaderEditor.SamplerNode;2;-684.4253,430.8239;Float;True;Property;_ROBOT2Gloss;ROBOT2 [Gloss];1;0;Create;True;0;0;False;0;74cac35a533fdec4d85e74983f139f31;74cac35a533fdec4d85e74983f139f31;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;9;-92.29102,469.2041;Float;False;Constant;_Float0;Float 0;4;0;Create;True;0;0;False;0;0.4;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.WorldReflectionVector;11;-1173.708,-391.4009;Float;False;False;1;0;FLOAT3;0,0,0;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SamplerNode;14;-912.2645,-264.0112;Float;True;Property;_magma_planets_hd_6sided;magma_planets_hd_6sided;4;0;Create;True;0;0;False;0;8f3789f268ed9b94283e31027ccd8172;8f3789f268ed9b94283e31027ccd8172;True;0;False;white;Auto;False;Object;-1;Auto;Cube;6;0;SAMPLER2D;;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;13;-817.3995,83.67316;Float;False;Constant;_Float1;Float 1;4;0;Create;True;0;0;False;0;0.2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;10;-600.685,-348.9634;Float;True;Property;_ROBOT2Normal;ROBOT2 [Normal];3;0;Create;True;0;0;False;0;a8098f6f5aabaf243a7a5b90587a5398;a8098f6f5aabaf243a7a5b90587a5398;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;5;-1061.071,187.9658;Float;True;Property;_TextureSample0;Texture Sample 0;2;0;Create;True;0;0;False;0;f11785d24370aa34f8cbe5ef27e75584;f11785d24370aa34f8cbe5ef27e75584;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ClampOpNode;12;-632.6514,-24.83136;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;1,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;1;-296.4441,-339.8802;Float;True;Property;_ROBOT2Albedo;ROBOT2 [Albedo];0;0;Create;True;0;0;False;0;3b7aa890fe020d64f9a036e36e21e5d5;3b7aa890fe020d64f9a036e36e21e5d5;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FunctionNode;15;-479.824,-18.67295;Float;False;BlinnPhongLightWrap;-1;;1;139fed909c1bc1a42a96c42d8cf09006;0;5;1;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;2;FLOAT;0;False;3;FLOAT;0;False;44;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ClampOpNode;8;-236.9904,285.0386;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;1,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;7;0,0;Float;False;True;2;Float;ASEMaterialInspector;0;0;StandardSpecular;Chrome Robot Dull;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;14;1;11;0
WireConnection;12;0;14;0
WireConnection;12;2;13;0
WireConnection;15;1;12;0
WireConnection;15;4;10;0
WireConnection;15;2;5;0
WireConnection;15;3;2;0
WireConnection;8;0;2;0
WireConnection;8;2;9;0
WireConnection;7;0;1;0
WireConnection;7;1;10;0
WireConnection;7;3;5;0
WireConnection;7;4;8;0
ASEEND*/
//CHKSM=685B8CF61AC686FCCA85AEABA555128F425A4130