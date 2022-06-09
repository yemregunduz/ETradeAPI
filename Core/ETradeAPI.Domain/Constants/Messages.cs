﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Domain.Constants
{
    public static class Messages
    {
        public static readonly string ProductAdded = "Ürün eklendi.";
        public static readonly string ProductDeleted = "Ürün silindi.";
        public static readonly string ProductsListed = "Ürünler listelendi.";
        public static readonly string ProductsListedByCurrentCategory = "Ürünler seçilen kategoriye göre listelendi.";
        public static readonly string ProductUpdated = "Ürün güncellendi.";
        public static readonly string ProductIdIsRequired = "Ürünün ID bilgisi boş geçilemez.";
        public static readonly string CategoryAdded = "Kategori eklendi.";
        public static readonly string ProductNotFound = "Ürün bulunamadı!";
        public static readonly string CategoryDeleted = "Kategori silindi";
        public static readonly string CategoriesListed = "Kategoriler listelendi.";
        public static readonly string CategoryUpdated = "Kategori güncellendi.";
        public static readonly string RestaurantAdded = "Restoran eklendi.";
        public static readonly string RestaurantDeleted = "Restoran silindi.";
        public static readonly string RestaurantListed = "Restoranlar listelendi.";
        public static readonly string RestaurantUpdated = "Restoran güncellendi.";
        public static readonly string OrderDeleted = "Sipariş iptal edildi";
        public static readonly string OrdersListedByTableId = "Masanın siparişleri listelendi.";
        public static readonly string OrderAdded = "Sipariş alındı.";
        public static readonly string OrdersListed = "Siparişler listelendi.";
        public static readonly string OrderUpdated = "Sipariş güncellendi.";
        public static readonly string OrderDetailCreated = "Sipariş detayı oluşturuldu.";
        public static readonly string OrderDetailDeleted = "Sipariş detayı silindi.";
        public static readonly string OrderDetailUpdated = "Sipariş detayı güncellendi.";
        public static readonly string TableUpdated = "Masa güncellendi.";
        public static readonly string TableDeleted = "Masa silindi.";
        public static readonly string TableAdded = "Masa eklendi.";
        public static readonly string TablesListedByRestaurantId = "Restorana ait tüm masalar listelendi.";
        public static readonly string AuthorizationDenied = "Bu operasyona yetkiniz yok.";
        public static readonly string UserAdded = "Kullanıcı eklendi.";
        public static readonly string ClaimsListed = "Kullanıcının yetkileri listelendi.";
        public static readonly string AccessTokenCreated = "Token oluşturuldu.";
        public static readonly string UserAlreadyExist = "Kullanıcı zaten sisteme kayıtlı.";
        public static readonly string UserNotFound = "Sisteme kayıtlı böyle bir kullanıcı yok.";
        public static readonly string PasswordError = "Girdiğiniz şifre hatalı.";
        public static readonly string SuccessfulLogin = "Giriş başarılı!";
        public static readonly string UserRegistered = "Kayıt başarılı!";
        public static readonly string CategoryNameIsRequired = "Kategori adı girilmelidir.";
        public static readonly string TableIdIsRequired = "Masa numarası girilmelidir.";
        public static readonly string OrderDateIsInvalid = "Geçmişe dönük sipariş verilemez.";
        public static readonly string OrderDateIsRequired = "Sipariş tarihi girilmelidir.";
        public static readonly string ProductIsRequired = "Ürün girmek zorunludur.";
        public static readonly string QuantityIsRequired = "Sipariş detayında miktar girmek zorunludur.";
        public static readonly string OrderIdIsRequired = "Sipariş detayı bir siparişe ait olmalıdır.";
        public static readonly string CategoryIdIsRequired = "Ürünün kategorisini girmek zorunludur.";
        public static readonly string ProductNameIsRequired = "Ürün adı boş bırakılamaz.";
        public static readonly string ProductNameIsInvalid = "Ürün adı en az 2 en fazla 150 karakter olmalıdır.";
        public static readonly string ProductDetailsListed = "Ürün detayı getirildi.";
        public static readonly string UnitPriceIsRequired = "Ürünün birim fiyatı boş bırakılamaz.";
        public static readonly string UnitPriceIsInvalid = "Ürünün birim fiyatı sıfırdan büyük olmalıdır.";
        public static readonly string ProductDescriptionIsInvalid = "Ürün açıklaması en az 250 karakter olmalıdır.";
        public static readonly string StockIsInvalid = "Stok eksi değer alamaz.";
        public static readonly string RestaurantIdIsRequired = "Ürünün hangi restorana ait olduğu girilmelidir.";
        public static readonly string QuantityIsInvalid = "Miktar sıfırdan büyük olmalıdır.";
        public static readonly string TaxNumberIsRequired = "Vergi numarası girmek zorunludur.";
        public static readonly string RestaurantNameIsInvalid = "Restoran adı maksimum 100 karakter olmalıdır.";
        public static readonly string TableNoIsRequired = "Masa mumarası girilmelidir";
        public static readonly string FirstNameIsRequired = "İsim alanı boş bırakılamaz.";
        public static readonly string FirstNameIsInvalid = "İsim 50 karakterden uzun olamaz.";
        public static readonly string LastNameIsRequired = "Soyad alanı boş bırakılamaz.";
        public static readonly string LastNameIsInvalid = "Soyad 50 karakterden uzun olamaz.";
        public static readonly string RestaurantIsRequired = "Kullanıcının çalıştığı restoran girilmelidir.";
        public static readonly string EmailIsRequired = "Kullanıcının emaili girilmelidir.";
        public static readonly string EmailIsInvalid = "Lütfen geçerli bir email adresi giriniz.";
        public static readonly string PasswordIsRequired = "Şifre alanı boş bırakılamaz.";
        public static readonly string PasswordIsInvalid = "Şifreniz en az bir büyük harf,bir sayı,bir özel karakterden oluşmalı ve en az 8 karakter olmalıdır.";
        public static readonly string UserStatusIsInactive = "Kullanıcının durumu pasif.";
        public static readonly string UserStatusUpdated = "Kullanıcı durumu güncellendi.";
        public static readonly string UserDeleted = "Kullanıcı silindi.";
        public static readonly string TitleAdded = "Ünvan eklendi";
        public static readonly string TitleDeleted = "Ünvan silindi";
        public static readonly string TitleListed = "Ünvanlar listelendi.";
        public static readonly string TitleUpdated = "Ünvan güncellendi.";
        public static readonly string UserDetailsListed = "Kullanıcı detayı listelendi.";
        public static readonly string UserUpdated = "Kullanıcı güncellendi.";
        public static readonly string UserImagePathUpdated = "Kullanıcının fotoğrafı güncellendi.";
        public static readonly string UserImageAdded = "Fotoğraf kullanıcıya eklendi.";
        public static readonly string ImageNotFound = "Fotoğraf bulunamadı.";
        public static readonly string UserImageDeleted = "Kullanıcın fotoğrafı silindi.";
        public static readonly string UserImageLimitExceeded = "Bir kullanıcıya ait fotoğraf sayısı 5'i geçemez.";
        public static readonly string UserImageUpdated = "Kullanıcının fotoğrafı güncellendi.";
        public static readonly string ProductImageDeleted = "Ürün fotoğrafı silindi.";
        public static readonly string ProductImageAdded = "Ürün fotoğrafı eklendi.";
        public static readonly string ProductImagePathIsRequired = "Resim linki alınamadı.";
        public static readonly string UserImagePathIsRequired = "Resim linki alınamadı.";
        public static readonly string UserIdIsRequired = "Kullanıcı bilgisi alınamadı.";
        public static readonly string OperationClaimAlreadyExist = "Bu yetki zaten mevcut.";
        public static readonly string OperationClaimAdded = "Yetki eklendi.";
        public static readonly string OperationClaimDeleted = "Yetki silindi.";
        public static readonly string OperationClaimsListed = "Yetkiler listelendi.";
        public static readonly string OperationClaimUpdated = "Yetki güncellendi.";
        public static readonly string OperationClaimNameCannotContainUpperCase = "Yetki büyük harf içeremez";
        public static readonly string UserAlreadyHasThisOperationClaim = "Kullanıcı zaten bu yetkiye sahip.";
        public static readonly string UserOperationClaimAdded = "Yetki kullanıcıya eklendi";
        public static readonly string UserOperationClaimDeleted = "Yetki kullanıcıdan silindi";
        public static readonly string UserOperationClaimUpdated = "Kullanıcının yetkisi güncellendi";
        public static readonly string UserOperationClaimsListed = "Kullanıcıya ait yetkiler listelendi";
        public static readonly string OperationClaimIdIsRequired = "Kullanıcıya eklemek istediğiniz yetkiyi seçiniz.";
        public static readonly string BirthOfDateIsRequired = "Doğum tarihi girmek zorunludur.";
        public static readonly string TcNoIsRequired = "T.C kimlik numarası girmek zorunludur.";
        public static readonly string TcNoIsInvalid = "Geçersiz T.C kimlik numarası!";
        public static readonly string DateOfRecruitmentIsRequired = "İşe giriş tarihi belirtilmelidir.";
        public static readonly string PasswordChanged = "Şifre değiştirildi.";
        public static readonly string SecurityCodeError = "Tek kullanımlık şifre hatalı!";
        public static readonly string OrderDetailsListed = "Sipariş detayları listelendi.";
        public static readonly string QrCodeCreated = "Qr code oluşturuldu.";
        public static readonly string QrCodeDeleted = "Qr code silindi.";
        public static readonly string QrCodeListedByRestaurantId = "Restorana ait tüm qr codelar listelendi.";
        public static readonly string QrCodeListedByTableId = "Masaya ait tüm qr codelar listelendi.";
        public static readonly string QrCodeUpdated = "Qr code güncellendi.";
        public static readonly string QrCodeLimitExceeded = "Bir masaya en fazla 12 adet qr code ekleyebilirsiniz.";
        public static readonly string StockIsRequired = "Stok bilgisi boş geçilemez.";
        public static readonly string SamePasswordError = "Eski şifrenizle yeni şifreniz aynı olamaz.";
    }
}
