// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Antique Robot Metal"
{
	Properties
	{
		_ROBOT2Albedo("ROBOT2 [Albedo]", 2D) = "white" {}
		_ROBOT2Gloss("ROBOT2 [Gloss]", 2D) = "white" {}
		_TextureSample0("Texture Sample 0", 2D) = "white" {}
		_ROBOT2Normal("ROBOT2 [Normal]", 2D) = "bump" {}
		_magma_planets_hd_6sided("magma_planets_hd_6sided", CUBE) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGINCLUDE
		#include "UnityCG.cginc"
		#include "UnityShaderVariables.cginc"
		#include "UnityPBSLighting.cginc"
		#include "Lighting.cginc"
		#pragma target 3.0
		#ifdef UNITY_PASS_SHADOWCASTER
			#undef INTERNAL_DATA
			#undef WorldReflectionVector
			#undef WorldNormalVector
			#define INTERNAL_DATA half3 internalSurfaceTtoW0; half3 internalSurfaceTtoW1; half3 internalSurfaceTtoW2;
			#define WorldReflectionVector(data,normal) reflect (data.worldRefl, half3(dot(data.internalSurfaceTtoW0,normal), dot(data.internalSurfaceTtoW1,normal), dot(data.internalSurfaceTtoW2,normal)))
			#define WorldNormalVector(data,normal) half3(dot(data.internalSurfaceTtoW0,normal), dot(data.internalSurfaceTtoW1,normal), dot(data.internalSurfaceTtoW2,normal))
		#endif
		struct Input
		{
			float2 uv_texcoord;
			float3 worldNormal;
			INTERNAL_DATA
			float3 worldPos;
			float3 worldRefl;
		};

		uniform sampler2D _ROBOT2Normal;
		uniform float4 _ROBOT2Normal_ST;
		uniform sampler2D _ROBOT2Albedo;
		uniform float4 _ROBOT2Albedo_ST;
		uniform samplerCUBE _magma_planets_hd_6sided;
		uniform sampler2D _TextureSample0;
		uniform float4 _TextureSample0_ST;
		uniform sampler2D _ROBOT2Gloss;
		uniform float4 _ROBOT2Gloss_ST;

		void surf( Input i , inout SurfaceOutputStandardSpecular o )
		{
			float2 uv_ROBOT2Normal = i.uv_texcoord * _ROBOT2Normal_ST.xy + _ROBOT2Normal_ST.zw;
			float3 tex2DNode6 = UnpackNormal( tex2D( _ROBOT2Normal, uv_ROBOT2Normal ) );
			o.Normal = tex2DNode6;
			float2 uv_ROBOT2Albedo = i.uv_texcoord * _ROBOT2Albedo_ST.xy + _ROBOT2Albedo_ST.zw;
			o.Albedo = tex2D( _ROBOT2Albedo, uv_ROBOT2Albedo ).rgb;
			float3 LightWrapVector47_g1 = (( 0.0 * 0.5 )).xxx;
			float3 CurrentNormal23_g1 = normalize( (WorldNormalVector( i , tex2DNode6 )) );
			float3 ase_worldPos = i.worldPos;
			#if defined(LIGHTMAP_ON) && UNITY_VERSION < 560 //aseld
			float3 ase_worldlightDir = 0;
			#else //aseld
			float3 ase_worldlightDir = normalize( UnityWorldSpaceLightDir( ase_worldPos ) );
			#endif //aseld
			float dotResult20_g1 = dot( CurrentNormal23_g1 , ase_worldlightDir );
			float NDotL21_g1 = dotResult20_g1;
			#if defined(LIGHTMAP_ON) && ( UNITY_VERSION < 560 || ( defined(LIGHTMAP_SHADOW_MIXING) && !defined(SHADOWS_SHADOWMASK) && defined(SHADOWS_SCREEN) ) )//aselc
			float4 ase_lightColor = 0;
			#else //aselc
			float4 ase_lightColor = _LightColor0;
			#endif //aselc
			float3 AttenuationColor8_g1 = ( ase_lightColor.rgb * 1 );
			float3 ase_worldReflection = WorldReflectionVector( i, float3( 0, 0, 1 ) );
			float4 temp_cast_1 = (0.2).xxxx;
			float4 clampResult7 = clamp( texCUBE( _magma_planets_hd_6sided, ase_worldReflection ) , float4( 0,0,0,0 ) , temp_cast_1 );
			float3 DiffuseColor70_g1 = ( ( ( max( ( LightWrapVector47_g1 + ( ( 1.0 - LightWrapVector47_g1 ) * NDotL21_g1 ) ) , float3(0,0,0) ) * AttenuationColor8_g1 ) + (UNITY_LIGHTMODEL_AMBIENT).rgb ) * clampResult7.rgb );
			float3 normalizeResult77_g1 = normalize( _WorldSpaceLightPos0.xyz );
			float3 ase_worldViewDir = normalize( UnityWorldSpaceViewDir( ase_worldPos ) );
			float3 normalizeResult28_g1 = normalize( ( normalizeResult77_g1 + ase_worldViewDir ) );
			float3 HalfDirection29_g1 = normalizeResult28_g1;
			float dotResult32_g1 = dot( HalfDirection29_g1 , CurrentNormal23_g1 );
			float SpecularPower14_g1 = exp2( ( ( 0.0 * 10.0 ) + 1.0 ) );
			float3 specularFinalColor42_g1 = ( AttenuationColor8_g1 * pow( max( dotResult32_g1 , 0.0 ) , SpecularPower14_g1 ) * 0.0 );
			o.Emission = ( DiffuseColor70_g1 + specularFinalColor42_g1 );
			float2 uv_TextureSample0 = i.uv_texcoord * _TextureSample0_ST.xy + _TextureSample0_ST.zw;
			o.Specular = tex2D( _TextureSample0, uv_TextureSample0 ).rgb;
			float2 uv_ROBOT2Gloss = i.uv_texcoord * _ROBOT2Gloss_ST.xy + _ROBOT2Gloss_ST.zw;
			float4 temp_cast_4 = (0.5).xxxx;
			float4 clampResult9 = clamp( tex2D( _ROBOT2Gloss, uv_ROBOT2Gloss ) , float4( 0,0,0,0 ) , temp_cast_4 );
			o.Smoothness = clampResult9.r;
			o.Alpha = 1;
		}

		ENDCG
		CGPROGRAM
		#pragma surface surf StandardSpecular keepalpha fullforwardshadows 

		ENDCG
		Pass
		{
			Name "ShadowCaster"
			Tags{ "LightMode" = "ShadowCaster" }
			ZWrite On
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.0
			#pragma multi_compile_shadowcaster
			#pragma multi_compile UNITY_PASS_SHADOWCASTER
			#pragma skip_variants FOG_LINEAR FOG_EXP FOG_EXP2
			#include "HLSLSupport.cginc"
			#if ( SHADER_API_D3D11 || SHADER_API_GLCORE || SHADER_API_GLES || SHADER_API_GLES3 || SHADER_API_METAL || SHADER_API_VULKAN )
				#define CAN_SKIP_VPOS
			#endif
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "UnityPBSLighting.cginc"
			struct v2f
			{
				V2F_SHADOW_CASTER;
				float2 customPack1 : TEXCOORD1;
				float4 tSpace0 : TEXCOORD2;
				float4 tSpace1 : TEXCOORD3;
				float4 tSpace2 : TEXCOORD4;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};
			v2f vert( appdata_full v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID( v );
				UNITY_INITIALIZE_OUTPUT( v2f, o );
				UNITY_TRANSFER_INSTANCE_ID( v, o );
				Input customInputData;
				float3 worldPos = mul( unity_ObjectToWorld, v.vertex ).xyz;
				half3 worldNormal = UnityObjectToWorldNormal( v.normal );
				half3 worldTangent = UnityObjectToWorldDir( v.tangent.xyz );
				half tangentSign = v.tangent.w * unity_WorldTransformParams.w;
				half3 worldBinormal = cross( worldNormal, worldTangent ) * tangentSign;
				o.tSpace0 = float4( worldTangent.x, worldBinormal.x, worldNormal.x, worldPos.x );
				o.tSpace1 = float4( worldTangent.y, worldBinormal.y, worldNormal.y, worldPos.y );
				o.tSpace2 = float4( worldTangent.z, worldBinormal.z, worldNormal.z, worldPos.z );
				o.customPack1.xy = customInputData.uv_texcoord;
				o.customPack1.xy = v.texcoord;
				TRANSFER_SHADOW_CASTER_NORMALOFFSET( o )
				return o;
			}
			half4 frag( v2f IN
			#if !defined( CAN_SKIP_VPOS )
			, UNITY_VPOS_TYPE vpos : VPOS
			#endif
			) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID( IN );
				Input surfIN;
				UNITY_INITIALIZE_OUTPUT( Input, surfIN );
				surfIN.uv_texcoord = IN.customPack1.xy;
				float3 worldPos = float3( IN.tSpace0.w, IN.tSpace1.w, IN.tSpace2.w );
				half3 worldViewDir = normalize( UnityWorldSpaceViewDir( worldPos ) );
				surfIN.worldPos = worldPos;
				surfIN.worldNormal = float3( IN.tSpace0.z, IN.tSpace1.z, IN.tSpace2.z );
				surfIN.worldRefl = -worldViewDir;
				surfIN.internalSurfaceTtoW0 = IN.tSpace0.xyz;
				surfIN.internalSurfaceTtoW1 = IN.tSpace1.xyz;
				surfIN.internalSurfaceTtoW2 = IN.tSpace2.xyz;
				SurfaceOutputStandardSpecular o;
				UNITY_INITIALIZE_OUTPUT( SurfaceOutputStandardSpecular, o )
				surf( surfIN, o );
				#if defined( CAN_SKIP_VPOS )
				float2 vpos = IN.pos;
				#endif
				SHADOW_CASTER_FRAGMENT( IN )
			}
			ENDCG
		}
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=16900
-1786;331;1586;730;1202.212;485.0709;1.554238;True;True
Node;AmplifyShaderEditor.WorldReflectionVector;1;-864.9909,-428.4131;Float;False;False;1;0;FLOAT3;0,0,0;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SamplerNode;2;-659.6133,-286.5547;Float;True;Property;_magma_planets_hd_6sided;magma_planets_hd_6sided;4;0;Create;True;0;0;False;0;8f3789f268ed9b94283e31027ccd8172;8f3789f268ed9b94283e31027ccd8172;True;0;False;white;Auto;False;Object;-1;Auto;Cube;6;0;SAMPLER2D;;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;3;-694.9669,32.19224;Float;False;Constant;_Float1;Float 1;4;0;Create;True;0;0;False;0;0.2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;4;-375.7082,393.8117;Float;True;Property;_ROBOT2Gloss;ROBOT2 [Gloss];1;0;Create;True;0;0;False;0;74cac35a533fdec4d85e74983f139f31;95ea940fe9b7316449585e00b96479fa;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;5;214.3775,432.1919;Float;False;Constant;_Float0;Float 0;4;0;Create;True;0;0;False;0;0.5;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;6;-291.9679,-385.9756;Float;True;Property;_ROBOT2Normal;ROBOT2 [Normal];3;0;Create;True;0;0;False;0;a8098f6f5aabaf243a7a5b90587a5398;9ab48e5d9bd610c428fca3f11715a8a2;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ClampOpNode;7;-399.8949,-52.80067;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;1,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;8;-752.3539,150.9536;Float;True;Property;_TextureSample0;Texture Sample 0;2;0;Create;True;0;0;False;0;f11785d24370aa34f8cbe5ef27e75584;4b005f611dc58144097110a2777f9981;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ClampOpNode;9;5.329895,335.3906;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;1,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;10;-84.26111,226.4393;Float;False;Constant;_Float4;Float 4;5;0;Create;True;0;0;False;0;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;11;100.8936,-422.1071;Float;True;Property;_ROBOT2Albedo;ROBOT2 [Albedo];0;0;Create;True;0;0;False;0;3b7aa890fe020d64f9a036e36e21e5d5;b39ad9229847c5b458211aeb81543c96;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FunctionNode;12;-60.3479,-73.78973;Float;False;BlinnPhongLightWrap;-1;;1;139fed909c1bc1a42a96c42d8cf09006;0;5;1;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;2;FLOAT;0;False;3;FLOAT;0;False;44;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;394.9528,-22.25086;Float;False;True;2;Float;ASEMaterialInspector;0;0;StandardSpecular;Antique Robot Metal;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;2;1;1;0
WireConnection;7;0;2;0
WireConnection;7;2;3;0
WireConnection;9;0;4;0
WireConnection;9;2;5;0
WireConnection;12;1;7;0
WireConnection;12;4;6;0
WireConnection;0;0;11;0
WireConnection;0;1;6;0
WireConnection;0;2;12;0
WireConnection;0;3;8;0
WireConnection;0;4;9;0
ASEEND*/
//CHKSM=35B01D9A2FFB6DF7DE1AD3984F234F5A5ECE4646